using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TDMT_DOAN.Areas.API.Models;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.APIView.Controllers
{
    public class LoginToApiController : Controller
    {
        public ActionResult Index(string request_token)
        {
            using (TMDT_DB3Entities entiti = new TMDT_DB3Entities())
            {
                NHACUNGCAP user = entiti.NHACUNGCAPs.Where(f => f.request_token == request_token).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid request_token.");
                }
            }
            LoginViewModelAPI temp = new LoginViewModelAPI();
            temp.request_token = request_token;
            return View(temp);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModelAPI model)
        {
            if (ModelState.IsValid)
            {
                using (TMDT_DB3Entities entiti = new TMDT_DB3Entities())
                {
                    NHACUNGCAP user = entiti.NHACUNGCAPs.Where(f => f.request_token == model.request_token).FirstOrDefault();
                    if (user == null || model.request_token == null)
                    {
                        ModelState.AddModelError("", "Invalid request_token.");
                    }
                    else
                    {
                        if (user.TENDANGNHAP != model.UserName || user.MATKHAU != model.Password)
                        {
                            ModelState.AddModelError("", "Invalid username or password.");
                        }
                        else
                        {
                            return RedirectToAction("Verifier", "LoginToApi", new { request_token = model.request_token, UserName = user.TENDANGNHAP });
                        }
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult Verifier(GetVerifier_token model)
        {
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Verifier(string action, GetVerifier_token model)
        {
            using (TMDT_DB3Entities entiti = new TMDT_DB3Entities())
            {
                NHACUNGCAP user = entiti.NHACUNGCAPs.Where(f => f.request_token == model.request_token).FirstOrDefault();
                if (user == null || user.TENDANGNHAP != model.UserName)
                {
                    ModelState.AddModelError("", "Invalid request_token or username");
                }
                else
                {
                    if (action == "No")
                    {
                        return Redirect(user.callback);
                    }
                    else
                    {
                        Guid g = Guid.NewGuid();
                        user.verifier_token = g.ToString();
                        entiti.SaveChanges();
                        return Redirect(user.callback + "?verifier_token=" + g.ToString());
                    }
                }
            }
            return View();
        }

        //public ActionResult Test()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Test(string action, LoginViewModel model)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        String strPathAndQuery = Request.Url.PathAndQuery;
        //        String strUrl = Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
        //        client.BaseAddress = new Uri(strUrl);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //var GetRequesttoken = new GetRequesttoken() { consumer_key = "60399900-438a-42d1-9558-3435f0230fff", callback = new Uri("https://www.google.com/") };
        //        var GetRequesttoken = new GetRequesttoken() { consumer_key = model.UserName, callback = new Uri(model.Password) };
        //        HttpResponseMessage response = await client.PostAsJsonAsync("oauth/request_token", GetRequesttoken);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Get the URI of the created resource.
        //            Uri gizmoUrl = response.Headers.Location;
        //        }
        //        string querystring = response.RequestMessage.RequestUri.ToString().Substring(response.RequestMessage.RequestUri.ToString().IndexOf('?'));
        //        System.Collections.Specialized.NameValueCollection parameters = System.Web.HttpUtility.ParseQueryString(querystring);
        //        string request_token = parameters["request_token"];
        //        return Redirect(response.RequestMessage.RequestUri.ToString());
        //    }
        //}
	}
}
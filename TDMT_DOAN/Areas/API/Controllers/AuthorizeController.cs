using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using TDMT_DOAN.Areas.API.Models;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthorizeController : ApiController
    {
        public HttpResponseMessage CreateResponse<T>(HttpStatusCode statusCode, T data)
        {
            return Request.CreateResponse(statusCode, data);
        }

        public HttpResponseMessage CreateResponse(HttpStatusCode httpStatusCode)
        {
            return Request.CreateResponse(httpStatusCode);
        }

        [HttpPost]
        [Route("oauth/request_token")]
        public async Task<HttpResponseMessage> GetRequest_token([FromBody] GetRequesttoken model)
        {
            Guid g = Guid.NewGuid();
            using (TMDT_DB3Entities entiti = new TMDT_DB3Entities())
            {
                NHACUNGCAP user = entiti.NHACUNGCAPs.Where(f => f.supplier_key == model.consumer_key).FirstOrDefault();
                if (user == null)
                {
                    return CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    user.callback = model.callback.ToString();
                    user.request_token = g.ToString();
                }
                entiti.SaveChanges();
            }
            String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
            String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Found);
            httpResponseMessage.Headers.Location = new Uri(strUrl + "APIView/LoginToApi/index?request_token=" + g.ToString());
            return httpResponseMessage;
        }

        //[HttpPost]
        //[Route("oauth/authenticate")]
        //public HttpResponseMessage GetVerifier_token([FromBody] GetVerifier_token model)
        //{
        //    var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Found);

        //    //httpResponseMessage.Headers.Location = new Uri(GLOBAL.currentUrl + "Login/index");
        //    httpResponseMessage.Headers.Location = new Uri("https://www.google.com");
        //    return httpResponseMessage;
        //}

        [HttpPost]
        [Route("oauth/access_token")]
        public async Task<HttpResponseMessage> GetAccess_token([FromBody] GetAccess_token model)
        {
            Guid g = Guid.NewGuid();
            using (TMDT_DB3Entities entiti = new TMDT_DB3Entities())
            {
                NHACUNGCAP user = entiti.NHACUNGCAPs.Where(f => f.supplier_key == model.consumer_key).FirstOrDefault();
                if (user == null || user.request_token != model.request_token || user.verifier_token != model.verifier_token)
                {
                    return CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    var request = HttpContext.Current.Request;
                    var tokenServiceUrl = request.Url.GetLeftPart(UriPartial.Authority) + request.ApplicationPath + "/Token";
                    using (var client = new HttpClient())
                    {
                        var requestParams = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("grant_type", "password"),
                            new KeyValuePair<string, string>("username", user.TENDANGNHAP),
                            new KeyValuePair<string, string>("password", user.MATKHAU)
                        };
                        var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                        var tokenServiceResponse = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
                        var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                        var responseCode = tokenServiceResponse.StatusCode;
                        var responseMsg = new HttpResponseMessage(responseCode)
                        {
                            Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                        };
                        return responseMsg;
                    }
                }
            }
        }
    }
}

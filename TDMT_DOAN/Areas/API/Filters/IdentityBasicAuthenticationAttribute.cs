using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TDMT_DOAN.Models;

namespace TDMT_DOAN.Areas.API.Filters
{
    public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
    {
        protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            //SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDBFilename=|DataDirectory|\\TMDT_DB.mdf;Integrated Security=True;Connect Timeout=30");
            //try
            //{
            //    con.Open();
            //}
            //catch(Exception e)
            //{

            //}


            //SqlCommand cmd = new SqlCommand("Select * from NHACUNGCAP", con);
            //List<NHACUNGCAP> list = new List<NHACUNGCAP>();
            //using (SqlDataReader reader = cmd.ExecuteReader())
            //{
            //    bool isExist = false;
            //    while (reader.Read())
            //    {
            //        NHACUNGCAP temp = new NHACUNGCAP();
            //        temp.MA = reader.GetString(0);
            //        temp.TENDANGNHAP = reader.GetString(1);
            //        temp.MATKHAU = reader.GetString(2);
            //        if (userName == temp.TENDANGNHAP || password == temp.MATKHAU)
            //        {
            //            isExist = true;
            //            break;
            //        }
            //    }
            //    if (isExist == false)
            //        return null;

            //}
            //con.Close();
            using (TMDT_DB3Entities entiti = new TMDT_DB3Entities())
            {
                try
                {
                    NHACUNGCAP ncc = entiti.NHACUNGCAPs.Where(f => f.TENDANGNHAP == userName).FirstOrDefault();
                    if (ncc == null)
                        return null;
                    if (ncc.MATKHAU != password)
                        return null;
                }
                catch (Exception e)
                {

                }

            }

            // Create a ClaimsIdentity with all the claims for this user.
            Claim nameClaim = new Claim(ClaimTypes.Name, userName);
            List<Claim> claims = new List<Claim> { nameClaim };

            // important to set the identity this way, otherwise IsAuthenticated will be false
            // see: http://leastprivilege.com/2012/09/24/claimsidentity-isauthenticated-and-authenticationtype-in-net-4-5/
            ClaimsIdentity identity = new ClaimsIdentity(claims, AuthenticationTypes.Basic);

            var principal = new ClaimsPrincipal(identity);
            return principal;
        }

    }
}
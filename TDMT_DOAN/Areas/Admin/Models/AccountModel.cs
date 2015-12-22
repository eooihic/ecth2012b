using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDMT_DOAN.Areas.Admin;
using System.Data.SqlClient;
using TDMT_DOAN.Areas.Admin.Code;
using TDMT_DOAN.Models;

namespace Models
{
    public class AccountModel
    {
        private TMDT_DB3Entities context = null;
        public AccountModel()
        {
            context = new TMDT_DB3Entities();
        }
        public bool Login(String userName, String passWord)
        {
            string passwordHash = HashSHA.encryptSHA(passWord);
            object[] sqlParams = new SqlParameter[]
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter("@PassWord",passwordHash),
            };
            var res = context.Database.SqlQuery<int>("SP_DANGNHAP @UserName,@PassWord",sqlParams).SingleOrDefault<int>();
            if (res!=0) return true;
            return false;
        }
    }
}
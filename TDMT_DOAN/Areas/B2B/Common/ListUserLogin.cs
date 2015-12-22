using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security;
namespace TDMT_DOAN.Areas.B2B.Common
{
    [Serializable]
    public class ListUserLogin
    {
        private static ListUserLogin onlyInstance =null;
        public List<UserLogin> list_user = null;
        private ListUserLogin()
        {
            list_user = new List<UserLogin>();
        }
        public static ListUserLogin getInstance()
        {
            if (onlyInstance == null)
            {
                return new ListUserLogin();
            }
            else
            {
                return onlyInstance;
            }
        }
        public bool AlreadyLogin(string username,string pass)
        {
            foreach(UserLogin item in list_user)
            {
                if (item.username == username && item.password == pass)
                    return true;
            }
            return false;
        }
        public bool AddUserLogin(string username,string pass)
        {
            if (!AlreadyLogin(username, pass))
            {
                list_user.Add(new UserLogin() { username = username, password = pass });
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
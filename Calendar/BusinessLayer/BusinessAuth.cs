using Calendar.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar.BusinessLayer
{
    public class BusinessAuth : IBusinessAuth
    {
        IRepositoryAuthentication _irep = null;

        public BusinessAuth():this(new Repository())
        {

        }

        public BusinessAuth(IRepositoryAuthentication irep)
        {
            _irep = irep;
        }
        public bool VerifyLogin(string uname, string pass)
        {
            bool isuser;
            if (_irep.VerifyLogin(uname, pass))
            {
                isuser = true;
                HttpContext current = HttpContext.Current;
                current.Session["LOGGEDIN"] = uname.ToString();
                current.Session.Timeout = 1;
            }
            else
            {
                isuser = false;
                HttpContext current = HttpContext.Current;
                current.Session["LOGGEDIN"] = "NOUSER";
            }
            return isuser;
        }
    }
}
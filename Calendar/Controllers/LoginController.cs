using Calendar.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calendar.ViewModels;
using Calendar.Models;
namespace Calendar.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(UserLoginViewModel uservw)
        {
            IBusinessAuth iba = new BusinessAuth();

            User user = new User
            {
                fname = uservw.name,
                pass = uservw.pass

            };
            
            if(iba.VerifyLogin(user.fname,user.pass) == true)
            {
                ViewBag.login = "Login success";
                Response.Redirect("/Home");
            }
            else
            {
                ViewBag.login = "Login false";
            }
            ViewBag.data = user;
            
            ViewBag.session = Session["LOGGEDIN"];
            //return loginAction();
            return View();
        }

    }
}
       
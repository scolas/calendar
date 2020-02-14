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

            if (iba.VerifyLogin(user.fname, user.pass) == true)
            {
               
                
                ViewBag.data = user;
                return RedirectToAction("Index", "Calendar");


            }
            else
            {
                ViewBag.login = "Login false";
                ViewBag.data = user;
                return View();
            }

            
        }

        public bool Login(User user)
        {
            IBusinessAuth iba = new BusinessAuth();
            bool loggedIn = false;
            if (iba.VerifyLogin(user.fname, user.pass) == true)
            {
                
                Response.Redirect("/Calendar");
            }
            else
            {
                ViewBag.login = "Login false";
            }
            return loggedIn;
        }

        public ActionResult Logout()
        {
            
            IBusinessAuth iba = new BusinessAuth();
            if (iba.Logout("", "") == true)
            {

                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            IBusinessAuth iba = new BusinessAuth();
            iba.createUser(user);
            return RedirectToAction("Index", "Login");
        }




    }
}
       
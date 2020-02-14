using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Calendar.BusinessLayer;
using Calendar.Models;
using Calendar.ViewModels;

namespace Calendar.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
  

        public ActionResult Index()
        {
            IBusinessAuth businessAuth = new BusinessAuth();
            if (!businessAuth.isLoggedIn()) {
                Month m1 = new Month();
                ViewBag.mData = m1;
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Month m1 = new Month();
                int year = (int)DateTime.Now.Year;
                int m = (int)DateTime.Now.Month;
                int days = DateTime.DaysInMonth(year, m);
                int month = DateTime.Now.Month;
                m1.month = "January";
                m1.days = days;
                m1.name = DateTime.Now.ToString("MMMM");
                m1.number = m;
                m1.year = year;
                ViewBag.mData = m1;
                return View();
            }
               
        }

      



        [HttpPost]
        [ActionName("preMonth")]
        public ActionResult preMonth()
        {
            IBusinessCalendar changeMonth = new BusinessCalendar();
            Month m1 = changeMonth.preMonth(5);
            ViewBag.days = m1.days;
            ViewBag.month = m1.name;
            ViewBag.year = "2020";
            ViewBag.mData = m1;
            return View();
        }


        



        [HttpPost]
        public ActionResult prevMonth(string id)
        {
            IBusinessCalendar changeMonth = new BusinessCalendar();
            Month m2 = changeMonth.preMonth(int.Parse(id));

            return Json(m2, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult nextMonth(string id)
        {
            IBusinessCalendar changeMonth = new BusinessCalendar();
            Month m2 = changeMonth.nextMonth(int.Parse(id));

            
            return Json(m2, JsonRequestBehavior.AllowGet);
        }





    }
}
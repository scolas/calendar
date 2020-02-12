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
           // }
            
            return View();
        }

       /* [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post(int mn)
        {
            int year = (int)DateTime.Now.Year;
            int m = (int)DateTime.Now.Month;
            int days = DateTime.DaysInMonth(year, m);
            int month1 = DateTime.Now.Month;
            ViewBag.days = (int)days;
            ViewBag.month = month1;
            ViewBag.year = year;
            Month m1 = new Month();
            m1.days = days;
            m1.name = DateTime.Now.ToString("MMMM");
            m1.number = days;
            m1.year = 2020;
            if(mn != null)
            {
                //int v2 = mn ?? default(int);
                IBusinessCalendar changeMonth = new BusinessCalendar();
                Month m2 = changeMonth.nextMonth(1);
                ViewBag.days = m2.days;
                ViewBag.month = m2.name;
                ViewBag.year = "2020";
                ViewBag.mData = m2;
            }
            else
            {
                ViewBag.mData = m;
            }
           
            return View();
        }*/



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
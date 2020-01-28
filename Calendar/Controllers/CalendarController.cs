using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calendar.BusinessLayer;
using Calendar.Models;
using Calendar.ViewModels;

namespace Calendar.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        [HttpGet]
        [ActionName("Index")]

        public ActionResult Index_Get(int? mn)
        {

            Month m1 = new Month();
            if (mn != null)
            {
                int v2 = mn ?? default(int);
                IBusinessCalendar changeMonth = new BusinessCalendar();
                m1 = changeMonth.nextMonth(v2);
                ViewBag.mData = m1;
            }
            else
            {
                int year = (int)DateTime.Now.Year;
                int m = (int)DateTime.Now.Month;
                int days = DateTime.DaysInMonth(year, m);
                int month = DateTime.Now.Month;
                m1.month = 1
                m1.days = days;
                m1.name = DateTime.Now.ToString("MMMM");
                m1.number = days;
                m1.year = 2020;
                ViewBag.mData = m1;
            }
            
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post(int? mn)
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
                int v2 = mn ?? default(int);
                IBusinessCalendar changeMonth = new BusinessCalendar();
                Month m2 = changeMonth.nextMonth(v2);
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
        }



        [HttpPost]
        [ActionName("preMonth")]
        public ActionResult preMonth()
        {
            IBusinessCalendar changeMonth = new BusinessCalendar();
            Month m1 = changeMonth.preMonth();
            ViewBag.days = m1.days;
            ViewBag.month = m1.name;
            ViewBag.year = "2020";
            ViewBag.mData = m1;
            return View();
        }


        
        public ActionResult nextMonth(int month)
        {
            IBusinessCalendar changeMonth = new BusinessCalendar();
            Month m2 = changeMonth.nextMonth(month);
            ViewBag.days = m2.days;
            ViewBag.month = m2.name;
            ViewBag.year = "2020";
            ViewBag.mData = m2;
            return RedirectToAction("Index", new { month = m2.name});
           // return View();
        }



    }
}
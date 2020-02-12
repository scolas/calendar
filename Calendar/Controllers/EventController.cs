using Calendar.BusinessLayer;
using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calendar.Controllers
{
    public class EventController : Controller
    {

        public Event globalE = new Event();
        // GET: Event
        [HttpGet]
        public ActionResult Index()
        {
            List<Event> eventList = new List<Event>();
            IBussinessEvent bussinessEvent = new BusinessEvent();
            eventList = bussinessEvent.events();

            return View(eventList);
        }

        [HttpPost]
        public ActionResult Index(Event e)
        {
            //Event event;
            IBussinessEvent events = new BusinessEvent();

            //events.getEvents(e);
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            IBussinessEvent bussinessEvent = new BusinessEvent();
            List<Event> eventsList = bussinessEvent.events();
            Event formEvent = eventsList.Find(x => x.id == id);
            return View(formEvent);
        }

        [HttpPost]
        public ActionResult Edit(Event editedEvents)
        {
            if (ModelState.IsValid)
            {
                IBussinessEvent editE = new BusinessEvent();
                bool update = editE.UpdateEvent(editedEvents);
                return RedirectToAction("Index");
            }
            return View(editedEvents);
        }






        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_View(int id)
        {
            IBussinessEvent bussinessEvent = new BusinessEvent();
            List<Event> eventsList = bussinessEvent.events();
            Event formEvent = eventsList.Find(x => x.id == id);
            return View(formEvent);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete(Event dEvent)
        {
           
            IBussinessEvent events = new BusinessEvent();
            if (events.DeleteEvent(dEvent))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }





        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(Event e)
        {

            IBussinessEvent createEvent = new BusinessEvent();

            if (ModelState.IsValid)
            {
                if (createEvent.CreateEvent(e)){
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Not working";
                    return View();
                }

            }

            return View();
        }

        public ActionResult getDayEvents(int days, int month, int year)
        {
            IBussinessEvent dayE = new BusinessEvent();
            
            Day d = new Day();
            d.day = days;
            d.year = year;
            d.month = month;

            DateTime d1 = new DateTime(d.year, d.month, d.day);
            d1.ToString("yyyy’-‘MM’-‘dd’ HH:mm:ss");

            DateTime d2 = d1;
            List<Event> e = dayE.GetDayEvents(d);


            ViewBag.day = days;
            ViewBag.month = month;
            ViewBag.year = year;

            ViewBag.data = d;
            ViewBag.events = e;

            return View(e);
            //return View();
        }

 
        // public JsonResult getDayEvent(int days, int month, int year)
        public ActionResult getDayEvent(int day, int month, int year)
        {
            IBussinessEvent dayE = new BusinessEvent();

            Day d = new Day();
            d.day = day;
            d.year = year;
            d.month = month;

            DateTime d1 = new DateTime(d.year, d.month, d.day);
            d1.ToString("yyyy’-‘MM’-‘dd’ HH:mm:ss");

            DateTime d2 = d1;
            List<Event> e = dayE.GetDayEvents(d);


            ViewBag.day = day;
            ViewBag.month = month;
            ViewBag.year = year;

            ViewBag.data = d;
            ViewBag.events = e;

            
            //return Json(e, JsonRequestBehavior.AllowGet);
            return View(e);
        }



        public ActionResult Editevent(Event eventToUpdate)
        {
            //Event event;
            IBussinessEvent events = new BusinessEvent();
            events.UpdateEvent(eventToUpdate);
            return View(eventToUpdate);
        }


    }       
}
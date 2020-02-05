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

        public ActionResult Dayevent(int days, int month, int year)
        {
            IBussinessEvent dayE = new BusinessEvent();
            var e = dayE.getEvent(days, month, year);
            /*
            DayViewModels day = new DayViewModels();
            day.name = e.name;
            day.event2 = e;*/


            Day d = new Day();
            d.name = "monday";
            d.day = days;

            ViewBag.day = days;
            ViewBag.month = month;
            ViewBag.year = year;

            ViewBag.data = d;
            ViewBag.events = e;


            return View();
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
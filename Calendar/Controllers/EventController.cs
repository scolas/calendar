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

            ViewBag.data = eventList;
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

        public ActionResult Edit2(int id, string name, string location,int day, string setBy) {

            globalE.id = id;
            globalE.name = name;
            globalE.location = location;
            globalE.day = day;
            globalE.setBy = setBy;

            return View();
        }

        public ActionResult Edit(Event es)
        {
            Event e = new Event();
            e = es;

            IBussinessEvent editE = new BusinessEvent();
            bool update = editE.UpdateEvent(e);
            return View();
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_View()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete(Event es)
        {
            //<td>@Html.ActionLink("Delete", "Delete", new { ids = 1, name ="", location ="", day = "", setBy = "" }) </td>
           // int ids, string name, string location, int day, string setBy
             Event e = new Event();
             e.id = 1;
             e.name = "test";
             e.location = "tets";
             e.day = 1;
             e.setBy = "test";
            IBussinessEvent events = new BusinessEvent();
            events.DeleteEvent(e);
            //var e = dayE.getEvent(1, 1, 1);
            return View();
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
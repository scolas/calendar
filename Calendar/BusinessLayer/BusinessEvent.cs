using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Calendar.DataLayer;
using Calendar.Models;
namespace Calendar.BusinessLayer
{
    public class BusinessEvent : IBussinessEvent
    {

        IRepositoryEvent _irep = null;

        public BusinessEvent() : this(new Repository())
        {

        }

        public BusinessEvent(IRepositoryEvent irep)
        {
            _irep = irep;
        }


        public bool CreateEvent(Event events)
        {
            bool i = _irep.SaveEvent(events);
            return i;
        }

        public bool DeleteEvent(Event events)
        {
            bool i = _irep.DeleteEvent(events);
            return i;
        }

        public List<Event> events()
        {
            List<Event> events = new List<Event>() {
                new Event(){id= 1, name="Dinner", location="new haven", day=8},
                new Event(){id= 2, name="Cookies", location="new haven", day=8},
                new Event(){id= 3, name="Dinner", location="new haven", day=8},
            };
            
            return events;
        }

        public Event getEvent(int day, int month, int year)
        {
            
            Event e = new Event();
            e = _irep.GetEvent(day);
           /* e.day = 8;
            e.name = "Dinner";
            e.location = "New havent Olives and oils";
            e.setBy = "Scott Colas";*/

            return e;
        }

        public List<Event> getEvents()
        {

            List <Event> e = new List<Event>();
            e = _irep.GetEvents();
            /* e.day = 8;
             e.name = "Dinner";
             e.location = "New havent Olives and oils";
             e.setBy = "Scott Colas";*/

            return e;
        }

        public bool SaveEvent(Event events){
           bool i =  _irep.SaveEvent(events);
            return i;
        }

        public void UpdateEvent(Event events)
        {
            _irep.UpdateEvent(events);
        }
    }








     
    
}
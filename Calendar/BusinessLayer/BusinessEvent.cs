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
            List<Event> e= new List<Event>();
            e = _irep.GetEvents();

            return e;
        }

        public Event getEvent(int day, int month, int year)
        { 
            Event e = new Event();
            e = _irep.GetEvent(day);
            return e;
        }

        public List<Event> getEvents()
        {

            List <Event> e = new List<Event>();
            e = _irep.GetEvents();

            return e;
        }

     
        public bool SaveEvent(Event events){
           bool i =  _irep.SaveEvent(events);
            return i;
        }

        public bool UpdateEvent(Event events)
        {
            bool i = _irep.UpdateEvent(events);
            return i;
        }

        List<Event> IBussinessEvent.GetDayEvents(Day day)
        {
            List<Event> e = new List<Event>();
            e = _irep.GetDayEvents(day);

            return e;
        }
    }








     
    
}
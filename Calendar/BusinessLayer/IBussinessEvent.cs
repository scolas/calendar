using Calendar.Models;
using System.Collections.Generic;

namespace Calendar.BusinessLayer
{
    public interface IBussinessEvent
    {
        Event getEvent(int day, int month, int year);
        List<Event> events();

        bool SaveEvent(Event events);

        bool CreateEvent(Event e);

        void UpdateEvent(Event events);

        bool DeleteEvent(Event events);
    }
}
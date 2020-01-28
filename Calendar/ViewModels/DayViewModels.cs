using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Calendar.Models;

namespace Calendar.ViewModels
{
    public class DayViewModels
    {
        public string name { get; set; }
        public int Number { get; set;}
        public  List<Event> events { get; set; }
        public Event event1 { get; set; }
        public Object event2 { get; set; }
        public string day { get; set; }

     
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar.Models
{
    public class Event
    {
        public int id { get; set; }
        public string name { get; set; }
        public int day { get; set; }
        public List<String> attendees { get; set; }
        public string location {get; set;}
        public string setBy { get; set; }

    }
}
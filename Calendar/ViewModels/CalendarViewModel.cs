using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calendar.ViewModels
{
    public class CalendarViewModel
    {
        public List<int> days { get; set; }
        public string month { get; set; }
    }
}
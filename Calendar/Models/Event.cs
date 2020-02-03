using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calendar.Models
{
    public class Event
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required] 
        public int day { get; set; }

         
        public List<String> attendees { get; set; }

        [Required]
        public string location {get; set;}
        [Required]
        public string setBy { get; set; }

    }
}
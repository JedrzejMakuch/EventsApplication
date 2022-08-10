using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsApplication.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Display(Name ="Event name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Date of start")]
        public DateTime DateOfStart { get; set; }

        [Display(Name = "Date of end")]
        public DateTime DateOfEnd { get; set; }

        public int Tickets { get; set; }

        public string Location { get; set; }
    }
}
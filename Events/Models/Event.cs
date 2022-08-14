using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsLibrary.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateOfStart { get; set; }

        public DateTime DateOfEnd { get; set; }

        public int Tickets { get; set; }

        public string Location { get; set; }
    }
}
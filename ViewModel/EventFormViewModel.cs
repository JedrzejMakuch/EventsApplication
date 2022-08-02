using EventsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApplication.ViewModel
{
    public class EventFormViewModel
    {
        public Event Event { get; set; }
        public Customer Customer { get; set; }

        public string Title
        {
            get
            {
                if (Event != null && Event.Id != 0)
                    return "Edit Event";

                return "New Event";
            }
        }

    }
}
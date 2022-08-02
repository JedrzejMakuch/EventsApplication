using EventsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApplication.ViewModel
{
    public class BuyTicketFormViewModel
    {
        public Event Event { get; set; }
        public Customer Customer { get; set; }
    }
}

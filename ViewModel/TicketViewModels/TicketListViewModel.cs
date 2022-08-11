﻿using EventsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApplication.ViewModel
{
    public class TicketListViewModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
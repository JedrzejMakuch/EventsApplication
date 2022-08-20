using EventsLibrary.Models;
using System.Collections.Generic;

namespace EventsLibrary.ViewModel
{
    public class TicketListViewModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
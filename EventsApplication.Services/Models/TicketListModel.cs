using EventsLibrary.Models;
using System.Collections.Generic;

namespace EventsApplication.Services.Models
{
    public class TicketListModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public IEnumerable<TicketModel> Tickets { get; set; }

        public TicketListModel(
            int eventId,
            string name,
            IEnumerable<TicketModel> tickets)
        {
            EventId = eventId;
            Name = name;
            Tickets = tickets;
        }
    }
}

using System.Collections.Generic;

namespace EventsApplication.ViewModels
{
    public class TicketListViewModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TicketListModel> Tickets { get; set; }

        public TicketListViewModel(
           int id,
           string name,
           IEnumerable<TicketListModel> tickets)
        {
           Id = id;
           Name = name;
           Tickets = tickets;
        }
    }
}
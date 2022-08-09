using EventsApplication.Models;
using EventsApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApplication.Service
{
    public interface ITicketService
    {
        IQueryable<Ticket> GetTicketWithIncludedCustomer(int Id);
        Ticket GetNewTicket();
        void BuyTicket(BuyTicketFormViewModel buyTicketFormViewModel, Event eventsInDb);
        Ticket GetTicketByEventId(int Id);
        void RefundTheTicket(ReturnTicketFormViewModel returnTicketFormViewModel);
        Ticket GetTicketById(int Id);
    }
}

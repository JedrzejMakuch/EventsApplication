using EventsLibrary.Models;
using EventsLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repositories
{
    public interface ITicketRepository
    {
        Ticket TicketId(int Id);
        IQueryable<Ticket> TicketIncludedEventCustomer(int Id);
        void BuyTickets(BuyTicketFormViewModel buyTicketFormViewModel, int Id);
        Ticket TicketByEventId(int Id);
        void RefundTicket(ReturnTicketFormViewModel returnTicketFormViewModel);
    }
}

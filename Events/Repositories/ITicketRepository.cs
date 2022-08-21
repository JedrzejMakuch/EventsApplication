using EventsLibrary.Models;
using System.Collections.Generic;

namespace Events.Repositories
{
    public interface ITicketRepository
    {

        Ticket TicketIncludedEventCustomer(int Id);

        IEnumerable<Ticket> GetTicketListForEvent(int EventId);

        void BuyTickets(Ticket Ticket);

        void RefundTicket(Ticket Ticket);

        Ticket TicketByTicketId(int Id);
    }
}

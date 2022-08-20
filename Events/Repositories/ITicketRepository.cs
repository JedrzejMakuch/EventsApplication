using EventsLibrary.Models;
using System.Collections.Generic;

namespace Events.Repositories
{
    public interface ITicketRepository
    {
        Ticket TicketById(int Id);
        Ticket TicketIncludedEventCustomer(int Id);
        IEnumerable<Ticket> GetTicketListForEvent(int EventId);
        void BuyTickets(Ticket Ticket);

        //void BuyTickets(BuyTicketModel BuyTicketModel);
        //Ticket TicketByEventId(int Id);
        void RefundTicket(Ticket Ticket);
        Ticket TicketBy(int Id);
    }
}

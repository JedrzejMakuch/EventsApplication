using System.Linq;
using Events.Repositories;
using EventsApplication.Services.Models;
using EventsLibrary.Models;

namespace EventsApplication.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IEventRepository _eventRepository;

        public TicketService(ITicketRepository ticketRepository, IEventRepository eventRepository)
        {
            _ticketRepository = ticketRepository;
            _eventRepository = eventRepository;
        }

        public TicketListModel GetTicketWithIncludedCustomer(int Id)
        {
            var ticket = _ticketRepository.TicketIncludedEventCustomer(Id);
            var tickets = _ticketRepository.GetTicketListForEvent(Id);

            return new TicketListModel(
                ticket.Event.Id,
                ticket.Event.Name,
                tickets.Select(e => new TicketModel(
                    e.Id,
                    e.Customer.FirstName,
                    e.Customer.LastName,
                    e.Customer.Email)));
        }

        public void BuyTicket(BuyTicketModel buyTicketModel)
        {

            var events = _eventRepository.EventId(buyTicketModel.EventId);

            var ticket = new Ticket
            {
                Customer = new Customer
                {
                    FirstName = buyTicketModel.FirstName,
                    LastName = buyTicketModel.LastName,
                    Email = buyTicketModel.Email
                },
                Event = events
            };
            _ticketRepository.BuyTickets(ticket);
            
        }

        public void RefundTheTicket(RefundTicketModel refundTicketModel)
        {
            var ticket = _ticketRepository.TicketByTicketId(refundTicketModel.Id);

            _ticketRepository.RefundTicket(ticket);
        }
    }
}
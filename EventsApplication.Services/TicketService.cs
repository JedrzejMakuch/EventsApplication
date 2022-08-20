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

        //public BuyTicketModel GetTicketById(int Id)
        //{

        //    var dto = _ticketRepository.TicketById(Id);
        //    var dtos = _ticketRepository.GetTicketList();
        //    return new BuyTicketModel(
        //        dto.Event.Id,
        //        dto.Customer.FirstName,
        //        dto.Customer.LastName,
        //        dto.Customer.Email,
        //        dtos,
        //        dto.Customer.Id,
        //        dto.Event.Name);
        //    //return _ticketRepository.TicketById(Id);
        //}

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

        //    public Ticket GetNewTicket()
        //    {
        //        return new Ticket();
        //    }

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

        //    public Ticket GetTicketByEventId(int Id)
        //    {
        //        return _ticketRepository.TicketByEventId(Id);
        //    }

        public void RefundTheTicket(RefundTicketModel refundTicketModel)
        {
            var ticket = _ticketRepository.TicketBy(refundTicketModel.Id);

            _ticketRepository.RefundTicket(ticket);
        }
        //}
    }
}
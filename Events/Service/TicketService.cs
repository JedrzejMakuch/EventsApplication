using EventsLibrary.Models;
using System.Linq;
using System.Data.Entity;
using EventsLibrary.ViewModel;
using Events.Repositories;

namespace EventsLibrary.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository; 
     
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Ticket GetTicketById(int Id)
        {
            return _ticketRepository.TicketId(Id);
        }
      
        public IQueryable<Ticket> GetTicketWithIncludedCustomer(int Id)
        {
            return _ticketRepository.TicketIncludedEventCustomer(Id);
        }

        public Ticket GetNewTicket()
        {
            return new Ticket();
        }

        public void BuyTicket(BuyTicketFormViewModel buyTicketFormViewModel, int Id)
        {
            _ticketRepository.BuyTickets(buyTicketFormViewModel, Id);
        }

        public Ticket GetTicketByEventId(int Id)
        {
            return _ticketRepository.TicketByEventId(Id);
        }
        
        public void RefundTheTicket(ReturnTicketFormViewModel returnTicketFormViewModel)
        {
            _ticketRepository.RefundTicket(returnTicketFormViewModel);
        }
    }
}
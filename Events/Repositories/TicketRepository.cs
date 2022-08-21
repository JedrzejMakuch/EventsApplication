using EventsLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Events.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEventRepository _eventRepository;

        public TicketRepository(ApplicationDbContext dbContext, IEventRepository eventRepository)
        {
            _dbContext = dbContext;
            _eventRepository = eventRepository;
        }

        public Ticket TicketByTicketId(int Id)
        {
            return _dbContext.Tickets.Include(e => e.Customer).Include(e => e.Event).FirstOrDefault(t => t.Id == Id);
        }

        public Ticket TicketIncludedEventCustomer(int Id)
        {
            return _dbContext.Tickets.Include(t => t.Event).Include(t => t.Customer).FirstOrDefault(t => t.Event.Id == Id);
        }

        public IEnumerable<Ticket> GetTicketListForEvent(int EventId)
        {
            return _dbContext.Tickets
                .Include(t => t.Customer)
                .Where(e => e.Event.Id == EventId)
                .AsNoTracking()
                .ToList();
        }

        public void BuyTickets(Ticket Ticket)
        {
           
            var evntInDb = _eventRepository.EventId(Ticket.Event.Id);
            var events = _dbContext.Events.FirstOrDefault(e => e.Id == evntInDb.Id);
            Ticket.Event = events;

            Ticket.Event.Tickets--;

            _dbContext.Customers.Add(Ticket.Customer);
            _dbContext.Tickets.Add(Ticket);

            _dbContext.SaveChanges();

        }

        public void RefundTicket(Ticket ticket)
        {
            var ticketInDb = TicketByTicketId(ticket.Id);

            if (ticket.Customer.FirstName == ticketInDb.Customer.FirstName &&
                ticket.Customer.LastName == ticketInDb.Customer.LastName &&
                ticket.Customer.Email == ticketInDb.Customer.Email)
            {
                ticket.Event.Tickets++;
                _dbContext.Customers.Remove(ticket.Customer);
                _dbContext.Tickets.Remove(ticket);
                _dbContext.SaveChanges();
            }
        }

    }
}

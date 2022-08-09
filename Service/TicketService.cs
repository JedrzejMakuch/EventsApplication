using EventsApplication.Models;
using System.Linq;
using System.Data.Entity;
using EventsApplication.ViewModel;
using System.Web.Mvc;

namespace EventsApplication.Service
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICustomerService _customerService;
     
        public TicketService(ApplicationDbContext applicationDbContext, ICustomerService customerService)
        {
            _dbContext = applicationDbContext;
            _customerService = customerService;
        }

        public Ticket GetTicketById(int Id)
        {
            return _dbContext.Tickets.FirstOrDefault(t => t.Event.Id == Id);
        }
        public IQueryable<Ticket> GetTicketWithIncludedCustomer(int Id)
        {
            return _dbContext.Tickets
                            .Include(t => t.Customer)
                            .Include(t => t.Event)
                            .Where(t => t.Event.Id == Id);
        }

        public Ticket GetNewTicket()
        {
            return new Ticket();
        }

        public void BuyTicket(BuyTicketFormViewModel buyTicketFormViewModel, Event eventsInDb)
        {

            var evnt = _dbContext.Events.FirstOrDefault(e => e.Id == eventsInDb.Id);
            if (evnt != null)
            {
                buyTicketFormViewModel.Ticket.Event = evnt;

                if (buyTicketFormViewModel.Ticket.Customer.Id == 0)
                {
                    _dbContext.Customers.Add(buyTicketFormViewModel.Ticket.Customer);
                }

                buyTicketFormViewModel.Ticket.Event.Tickets--;
                _dbContext.Tickets.Add(buyTicketFormViewModel.Ticket);

                _dbContext.SaveChanges();

            }
        }

        public Ticket GetTicketByEventId(int Id)
        {
            return _dbContext.Tickets
                .Include(t => t.Event)
                .Include(t => t.Customer)
                .FirstOrDefault(c => c.Id == Id);
        }

        public void RefundTheTicket(ReturnTicketFormViewModel returnTicketFormViewModel)
        {
            var ticket = GetTicketByEventId(returnTicketFormViewModel.Ticket.Id);

            if (_customerService.ValidateCustomer(returnTicketFormViewModel, ticket))
            {
                ticket.Event.Tickets++;
                _dbContext.Customers.Remove(ticket.Customer);
                _dbContext.Tickets.Remove(ticket);
                _dbContext.SaveChanges();
            }
        }
    }
}
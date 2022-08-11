using EventsApplication.Models;
using System.Linq;
using System.Data.Entity;
using EventsApplication.ViewModel;

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
                

                if (buyTicketFormViewModel.CustomerId == 0)
                {
                    var viewModel = new BuyTicketFormViewModel
                    {
                        Ticket = new Ticket
                        {
                            Customer = new Customer
                            {
                                FirstName = buyTicketFormViewModel.FirstName,
                                LastName = buyTicketFormViewModel.LastName,
                                Email = buyTicketFormViewModel.Email,
                                IsRegistered = null,
                            },
                            Event = evnt,
                          
                        },
                       
                    };
                     viewModel.Ticket.Event.Tickets--;
                    _dbContext.Customers.Add(viewModel.Ticket.Customer);
                    _dbContext.Tickets.Add(viewModel.Ticket);
                }

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
            // var ticket = GetTicketByEventId(returnTicketFormViewModel.Ticket.Id);
            var ticket = GetTicketByEventId(returnTicketFormViewModel.Id);

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
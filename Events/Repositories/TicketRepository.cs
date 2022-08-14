using EventsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EventsLibrary.ViewModel;
using EventsLibrary.Service;

namespace Events.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEventRepository _eventRepository;
        private readonly ICustomerService _customerService;

        public TicketRepository(ApplicationDbContext dbContext, IEventRepository eventRepository, ICustomerService customerService)
        {
            _dbContext = dbContext;
            _eventRepository = eventRepository;
            _customerService = customerService;
        }

        public Ticket TicketId(int Id)
        {
            return _dbContext.Tickets.FirstOrDefault(t => t.Event.Id == Id);
        }

        public IQueryable<Ticket> TicketIncludedEventCustomer(int Id)
        {
            return _dbContext.Tickets
                            .Include(t => t.Customer)
                            .Include(t => t.Event)
                            .Where(t => t.Event.Id == Id);
        }

        public void BuyTickets(BuyTicketFormViewModel buyTicketFormViewModel, int Id)
        {
            var eventsInDb = _eventRepository.EventId(Id);
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

        public Ticket TicketByEventId(int Id)
        {
            return _dbContext.Tickets
                .Include(t => t.Event)
                .Include(t => t.Customer)
                .FirstOrDefault(c => c.Id == Id);
        }

        public void RefundTicket(ReturnTicketFormViewModel returnTicketFormViewModel)
        {
            var ticket = TicketByEventId(returnTicketFormViewModel.Id);

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

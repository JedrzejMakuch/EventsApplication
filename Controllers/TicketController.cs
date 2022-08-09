using EventsApplication.Models;
using EventsApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EventsApplication.Service;

namespace EventsApplication.Controllers
{
    // Robic kilka metod GetCusomerId(), GetCustomerList();
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly EventService _eventService;
        private readonly ICustomerService _customerService;

        public TicketController(ICustomerService customerService, ApplicationDbContext applicationDbContext)
        {
            _customerService = customerService;
            _dbContext = applicationDbContext;
        }

        public TicketController()
        {
            _dbContext = new ApplicationDbContext();
            _eventService = new EventService();
        }

        public ActionResult TicketList(int Id)
        {

            var tickets = _dbContext.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Event)
                .Where(t => t.Event.Id == Id);
            var events = _dbContext.Events.FirstOrDefault(e => e.Id == Id);
            var viewModel = new TicketListViewModel
            {
                Tickets = tickets,
                Event = events
            };
            return View("TicketList", viewModel);
        }

        public ActionResult BuyTicket(int Id)
        {
            var events = _dbContext.Events.FirstOrDefault(e => e.Id == Id);

            var viewModel = new BuyTicketFormViewModel
            {
                Event = events,
                Ticket = new Ticket(),
                Customer = new Customer()
            };

            return View("BuyTicketForm", viewModel);
        }
        [HttpPost]
        public ActionResult BuyTicketSave(BuyTicketFormViewModel buyTicketFormViewModel)
        {
            var eventsInDb = _dbContext.Events.FirstOrDefault(e => e.Id == buyTicketFormViewModel.Event.Id);

            buyTicketFormViewModel.Ticket.Event = eventsInDb;

            if (buyTicketFormViewModel.Ticket.Customer.Id == 0)
            {
                _dbContext.Customers.Add(buyTicketFormViewModel.Ticket.Customer);
            }

            eventsInDb.Tickets--;
            _dbContext.Tickets.Add(buyTicketFormViewModel.Ticket);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Event");
        }
        public ActionResult RefundTicket()
        {
            return View("RefundTicketForm");
        }

        [HttpPost]
        public ActionResult RefundTicketSave(ReturnTicketFormViewModel returnTicketFormViewModel)
        {

            var ticket = _dbContext.Tickets
                .Include(t => t.Event)
                .Include(t => t.Customer)
                .FirstOrDefault(c => c.Id == returnTicketFormViewModel.Ticket.Id);

            if (returnTicketFormViewModel.Customer.FirstName == ticket.Customer.FirstName &&
                returnTicketFormViewModel.Customer.LastName == ticket.Customer.LastName &&
                returnTicketFormViewModel.Customer.Email == ticket.Customer.Email)
            {
                ticket.Event.Tickets++;
                _dbContext.Customers.Remove(ticket.Customer);
                _dbContext.Tickets.Remove(ticket);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Event");
        }
    }
}

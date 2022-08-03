using EventsApplication.Models;
using EventsApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EventsApplication.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        
        public ActionResult TicketList(int Id)
        {

            var events = _dbContext.Events.Single(e => e.Id == Id);
            var customers = _dbContext.Customers.ToList();
            
            var viewModel = new BuyTicketFormViewModel
            {
                Customers = customers,
                Event = events,
            };
            return View(viewModel);
        }
        public ActionResult BuyTicket(int Id)
        {
            var events = _dbContext.Events.SingleOrDefault(e => e.Id == Id);
            var viewModel = new BuyTicketFormViewModel
            {
                Event = events,
                Customer = new Customer()
            };
            return View("BuyTicketForm", viewModel);
        }

        [HttpPost]
        public ActionResult BuyTicketSave(Customer Customer)
        {
            var eventsInDb = _dbContext.Events.SingleOrDefault(e => e.Id == Customer.EventId);

            if (Customer.Id == 0)
            {
                _dbContext.Customers.Add(Customer);
            }
           
            eventsInDb.Tickets--;
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Event");
        }

        public ActionResult RefundTicket(int Id)
        {
            var events = _dbContext.Events.Single(e => e.Id == Id);

            if (events == null)
                return new EmptyResult();

            var viewModel = new BuyTicketFormViewModel
            {
                Customer = new Customer(),
                Event = events,
            };

            return View("RefundTicketForm", viewModel);

        }

        [HttpPost]
        public ActionResult RefundTicketSave(Customer Customer)
        {
            var CustomersInDb = _dbContext.Customers.ToList();
            var CustomerInDb = CustomersInDb.Single(c => c.Id == Customer.Id);
            var events = _dbContext.Events.SingleOrDefault(e => e.Id == Customer.EventId);

            if (CustomerInDb == null)
            {
                Console.WriteLine("Nie ma takiego Id");
            }
            if(CustomerInDb.Email == Customer.Email && CustomerInDb.FirstName == Customer.FirstName && CustomerInDb.LastName == Customer.LastName)
            {
                _dbContext.Customers.Remove(CustomerInDb);
                events.Tickets++;
                _dbContext.SaveChanges();
            } else
            {
                Console.WriteLine("Nie poprawne dane");
            }
            

            return RedirectToAction("Index", "Event");
        }

        
    }
}
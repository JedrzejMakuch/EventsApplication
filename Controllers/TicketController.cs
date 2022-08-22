using EventsApplication.Services.Abstractions;
using EventsApplication.ViewModels;
using System.Linq;
using System.Web.Mvc;
using EventsApplication.Service;
using EventsApplication.Services.Models;

namespace EventsApplication.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IEventService _eventService;
     
        public TicketController(ITicketService ticketService, IEventService eventService)
        {
            _ticketService = ticketService;
            _eventService = eventService;
        }

        public ActionResult TicketList(int Id)
        {
            var ticket = _ticketService.GetTicketWithIncludedCustomer(Id);
            var viewModel = new TicketListViewModel(
                ticket.EventId,
                ticket.Name,
                ticket.Tickets.Select(e => new ViewModels.TicketListModel(
                    e.Id,
                    e.FirstName,
                    e.LastName,
                    e.Email)));
            
            return View("TicketList", viewModel);
        }

        public ActionResult BuyTicket(int Id)
        {
            var viewModel = new BuyTicketViewModel
            {
                EventId = Id,
            };

            return View("BuyTicketForm", viewModel);
        }

        [HttpPost]
        public ActionResult BuyTicketSave(BuyTicketViewModel buyTicketViewModel)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                var viewModelState = new BuyTicketViewModel()
                {
                    EventId = buyTicketViewModel.EventId,
                    FirstName = buyTicketViewModel.FirstName,
                    LastName = buyTicketViewModel.LastName,
                    Email = buyTicketViewModel.Email
                };
                return View("BuyTicketForm", viewModelState);
            }
            var viewModel = new BuyTicketModel(
                buyTicketViewModel.EventId,
                buyTicketViewModel.FirstName,
                buyTicketViewModel.LastName,
                buyTicketViewModel.Email);
            _ticketService.BuyTicket(viewModel);

            return RedirectToAction("Index", "Event");
        }

        public ActionResult RefundTicket()
        {
            return View("RefundTicketForm");
        }

        [HttpPost]
        public ActionResult RefundTicketSave(RefundTicketViewModel refundTicketViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModelState = new RefundTicketViewModel(
                    refundTicketViewModel.Id,
                    refundTicketViewModel.FirstName,
                    refundTicketViewModel.FirstName,
                    refundTicketViewModel.Email);
                return View("RefundTicketForm", viewModelState);
            }
            var refundTicketModel = new RefundTicketModel(
                refundTicketViewModel.Id,
                refundTicketViewModel.FirstName,
                refundTicketViewModel.LastName,
                refundTicketViewModel.Email);

            _ticketService.RefundTheTicket(refundTicketModel);

            return RedirectToAction("Index", "Event");
        }

    }
}

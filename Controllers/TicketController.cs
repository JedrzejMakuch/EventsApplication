using EventsApplication.ViewModel;
using System.Web.Mvc;
using EventsApplication.Service;
using EventsApplication.Models;

namespace EventsApplication.Controllers
{
    public class TicketController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ITicketService _ticketService;
        private readonly IEventService _eventService;
     
        public TicketController(ICustomerService customerService, ITicketService ticketService, IEventService eventService)
        {
            _customerService = customerService;
            _ticketService = ticketService;
            _eventService = eventService;
        }

        public ActionResult TicketList(int Id)
        {
            var viewModel = new TicketListViewModel
            {
                Tickets = _ticketService.GetTicketWithIncludedCustomer(Id),
                EventId = _eventService.GetEventId(Id).Id,
                Name = _eventService.GetEventId(Id).Name
            };
            return View("TicketList", viewModel);
        }

        public ActionResult BuyTicket(int Id)
        {
            var viewModel = new BuyTicketFormViewModel
            {
                EventId = _eventService.GetEventId(Id).Id,
                Ticket = _ticketService.GetNewTicket(),
            };

            return View("BuyTicketForm", viewModel);
        }

        [HttpPost]
        public ActionResult BuyTicketSave(BuyTicketFormViewModel buyTicketFormViewModel)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {

                return View("BuyTicketForm");
            }
            _ticketService.BuyTicket(buyTicketFormViewModel, _eventService.GetEventId(buyTicketFormViewModel.EventId));

            return RedirectToAction("Index", "Event");
        }

        public ActionResult RefundTicket()
        {
            return View("RefundTicketForm");
        }

        [HttpPost]
        public ActionResult RefundTicketSave(ReturnTicketFormViewModel returnTicketFormViewModel)
        {
            if (!ModelState.IsValid)
            {

                return View("RefundTicketForm");
            }
            _ticketService.RefundTheTicket(returnTicketFormViewModel);

            return RedirectToAction("Index", "Event");
        }

    }
}

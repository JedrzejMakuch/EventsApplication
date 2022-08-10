using EventsApplication.ViewModel;
using System.Web.Mvc;
using EventsApplication.Service;

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
                Event = _eventService.GetEventId(Id)
            };
            return View("TicketList", viewModel);
        }

        public ActionResult BuyTicket(int Id)
        {
            var viewModel = new BuyTicketFormViewModel
            {
                Event = _eventService.GetEventId(Id),
                Ticket = _ticketService.GetNewTicket(),
                Customer = _customerService.GetNewCustomer()
            };

            return View("BuyTicketForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult BuyTicketSave(BuyTicketFormViewModel buyTicketFormViewModel)
        {
            _ticketService.BuyTicket(buyTicketFormViewModel, _eventService.GetEventId(buyTicketFormViewModel.Event.Id));

            return RedirectToAction("Index", "Event");
        }

        public ActionResult RefundTicket()
        {
            return View("RefundTicketForm");
        }

        [HttpPost]
        public ActionResult RefundTicketSave(ReturnTicketFormViewModel returnTicketFormViewModel)
        {
            _ticketService.RefundTheTicket(returnTicketFormViewModel);

            return RedirectToAction("Index", "Event");
        }

    }
}

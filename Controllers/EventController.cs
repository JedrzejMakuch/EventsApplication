using System.Linq;
using System.Web.Mvc;
using EventsApplication.ViewModels;
using EventsApplication.Services.Abstractions;
using EventsApplication.Services.Models;

namespace EventsApplication.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
    
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public ActionResult Index()
        {
            var events = _eventService.GetEventList();
            var viewModel = events.Select(e => new EventDetailsViewModel(
                e.Id,
                e.Name,
                e.Description,
                e.Location,
                e.StartDate,
                e.EndDate,
                e.TicketsLeft));

            return View(viewModel);
        }

        public ActionResult New()
        {
            return View("EventForm");
        }

        public ActionResult Details(int Id)
        {
            var eventDetails = _eventService.GetEventById(Id);

            var viewModel = new EventDetailsViewModel(
                eventDetails.Id,
                eventDetails.Name,
                eventDetails.Description,
                eventDetails.Location,
                eventDetails.StartDate,
                eventDetails.EndDate,
                eventDetails.TicketsLeft);
            return View(viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var eventEdit = _eventService.EditEvent(Id);
            var viewModel = new EventDetailsViewModel(
                eventEdit.Id,
                eventEdit.Name,
                eventEdit.Description,
                eventEdit.Location,
                eventEdit.StartDate,
                eventEdit.EndDate,
                eventEdit.TicketsLeft);

            return View("EventForm", viewModel);
        }


        [HttpPost]
        public ActionResult Save(EventDetailsViewModel EventDetailsViewModel)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                var viewModel = new EventDetailsViewModel(
                    EventDetailsViewModel.Id,
                    EventDetailsViewModel.Name,
                    EventDetailsViewModel.Description,
                    EventDetailsViewModel.Location,
                    EventDetailsViewModel.StartDate,
                    EventDetailsViewModel.EndDate,
                    EventDetailsViewModel.TicketsLeft);
               return View("EventForm", viewModel);
            }

            var eventModel = new EventModel
            (
                EventDetailsViewModel.Id,
                EventDetailsViewModel.Name,
                EventDetailsViewModel.Description,
                EventDetailsViewModel.Location,
                EventDetailsViewModel.StartDate,
                EventDetailsViewModel.EndDate,
                EventDetailsViewModel.TicketsLeft
            );
            _eventService.SaveEvent(eventModel);

            return RedirectToAction("Index", "Event");
        }

        public ActionResult Delete(int Id)
        {
            _eventService.DeleteEvent(Id);

            return RedirectToAction("Index", "Event");
        }

    }
}
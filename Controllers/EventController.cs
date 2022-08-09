using EventsApplication.Service;
using EventsApplication.ViewModel;
using System.Web.Mvc;


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
            return View(_eventService.GetEventList());
        }

        public ActionResult New()
        {
            var viewModel = new EventFormViewModel
            {
                Event = _eventService.GetNewEvent()
            };
            return View("EventForm", viewModel);
        }

        public ActionResult Details(int Id)
        {
            return View(_eventService.GetEventId(Id));
        }

        public ActionResult Edit(int Id)
        {
            var viewModel = new EventFormViewModel
            {
                Event = _eventService.GetEventId(Id),
            };

            return View("EventForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(EventFormViewModel newEventFormViewModel)
        {
            _eventService.SaveNewEditEvent(newEventFormViewModel);

            return RedirectToAction("Index", "Event");
        }

        public ActionResult Delete(int Id)
        {
            _eventService.DeleteEvent(Id);

            return RedirectToAction("Index", "Event");
        }

    }
}
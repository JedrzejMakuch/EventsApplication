using EventsApplication.Service;
using EventsApplication.ViewModel;
using System.Linq;
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
            return View("EventForm");
        }

        public ActionResult Details(int Id)
        {
            return View(_eventService.GetEventId(Id));
        }

        public ActionResult Edit(int Id)
        {
            EventFormViewModel viewModel = _eventService.EditEvent(Id);

            return View("EventForm", viewModel);
        }


        [HttpPost]
        public ActionResult Save(EventFormViewModel newEventFormViewModel)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {

                return View("EventForm");
            }
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
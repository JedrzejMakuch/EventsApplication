using EventsApplication.Models;
using EventsApplication.ViewModel;
using System.Linq;
using System.Web.Mvc;


namespace EventsApplication.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EventController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var events = _dbContext.Events.ToList();
            return View(events);
        }



        public ActionResult New()
        {
            var viewModel = new EventFormViewModel
            {
                Event = new Event()
            };
            return View("EventForm", viewModel);
        }

        public ActionResult Details(int Id)
        {
            var events = _dbContext.Events.SingleOrDefault(e => e.Id == Id);

            return View(events);
        }

        public ActionResult Edit(int Id)
        {
            var events = _dbContext.Events.FirstOrDefault(e => e.Id == Id);

            var viewModel = new EventFormViewModel
            {
                Event = events
            };

            return View("EventForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(EventFormViewModel newEventFormViewModel)
        {

            if (newEventFormViewModel.Event.Id == 0)
                _dbContext.Events.Add(newEventFormViewModel.Event);
            else
            {
                var eventInDb = _dbContext.Events.Single(e => e.Id == newEventFormViewModel.Event.Id);
                eventInDb.Name = newEventFormViewModel.Event.Name;
                eventInDb.Description = newEventFormViewModel.Event.Description;
                eventInDb.Tickets = newEventFormViewModel.Event.Tickets;
                eventInDb.DateOfStart = newEventFormViewModel.Event.DateOfStart;
                eventInDb.DateOfEnd = newEventFormViewModel.Event.DateOfEnd;
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Event");
        }

        public ActionResult Delete(int Id)
        {
            var events = _dbContext.Events.FirstOrDefault(e => e.Id == Id);

            _dbContext.Events.Remove(events);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Event");
        }
    }
}
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

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
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
            if (events == null)
                return new EmptyResult();


            return View(events);
        }

        public ActionResult Edit(int Id)
        {
            var events = _dbContext.Events.SingleOrDefault(e => e.Id == Id);

            if (events == null)
                return new EmptyResult();

            var viewModel = new EventFormViewModel
            {
                Event = events
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Event Event)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new EventFormViewModel { Event = Event };
                return View("EventForm", viewModel);
            }


            if (Event.Id == 0)
                _dbContext.Events.Add(Event);
            else
            {
                var eventInDb = _dbContext.Events.Single(e => e.Id == Event.Id);
                eventInDb.Name = Event.Name;
                eventInDb.Description = Event.Description;
                eventInDb.Tickets = Event.Tickets;
                eventInDb.DateOfStart = Event.DateOfStart;
                eventInDb.DateOfEnd = Event.DateOfEnd;
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Event");
        }

        public ActionResult Delete(int Id)
        {
            var events = _dbContext.Events.Single(e => e.Id == Id);
            if (events.Id == null)
            {
                return new EmptyResult();
            }

            _dbContext.Events.Remove(events);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Event");
        }
    }
}
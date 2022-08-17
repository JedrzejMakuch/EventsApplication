using EventsLibrary.ViewModel;
using System.Linq;
using System.Web.Mvc;
using EventsApplication.ViewModels;
using EventsApplication.Services.Abstractions;

namespace EventsApplication.Controllers
{
    // Mozna zastosowac przed kontrolerem zeby wszystkie akcje w kontrolerze byly chronione logowaniem
    //[Authorize]
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

        // Authorize odpowiada za to, ze musisz byc zalogowany zeby jej uzyc i przenosi Cie do logowania
        //[Authorize]
        // Do authorize mozna dodawac role, jezeli dodasz role, to tylko dla tej roli bedzie dostepna ta akcja
        // Role ustawiasz w Database pod table dbo.AspNetRoles dodajesz tam jakie Id ma jaka rola
        // pozniej w AspNetUserRoles ustawiasz, kto ma miec jaka role
        // Mozna ustawic, ze user jest tez adminem, albo zrobic [Authorize(Roles = "User", "Admin")], bo inaczej
        // jako admin nie masz dostepu tam gdzie user, bo jestes po prostu innym typem uzytkownika
        //[Authorize(Roles ="Admin")]
        //[Authorize]
        public ActionResult New()
        {
            return View("EventForm");
        }

        // Allow Anonumous pozwala wchodzic na te akcje bez logowania, mimio, ze caly kontroler ma [Authorize]
        //[AllowAnonymous]
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
            //EventFormViewModel viewModel = _eventService.EditEvent(Id);

            //return View("EventForm", viewModel);
            return Content("edit");
        }


        [HttpPost]
        public ActionResult Save(EventFormViewModel newEventFormViewModel)
        {
            //ModelState.Remove("Id");
            //if (!ModelState.IsValid)
            //{

            //    return View("EventForm");
            //}
            //_eventService.SaveNewEditEvent(newEventFormViewModel);

            //return RedirectToAction("Index", "Event");
            return Content("save");
        }

        public ActionResult Delete(int Id)
        {
            //_eventService.DeleteEvent(Id);

            //return RedirectToAction("Index", "Event");
            return Content("delete");
        }

    }
}
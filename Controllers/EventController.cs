using EventsLibrary.Service;
using EventsLibrary.ViewModel;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

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
            return View(_eventService.GetEventList());
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
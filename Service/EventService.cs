using EventsApplication.Models;
using EventsApplication.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace EventsApplication.Service
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _dbContext;
      
        public EventService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public IEnumerable<Event> GetEventList()
        {
            return _dbContext.Events.ToList();
        }

        public Event GetEventId(int Id)
        {
            return _dbContext.Events.SingleOrDefault(c => c.Id == Id);
        }

        public void SaveNewEditEvent(EventFormViewModel newEventFormViewModel)
        {

            if (newEventFormViewModel.Id == 0)
            {
                var events = new Event
                {
                    Id = newEventFormViewModel.Id,
                    Name = newEventFormViewModel.Name,
                    Description = newEventFormViewModel.Description,
                    DateOfStart = newEventFormViewModel.DateOfStart,
                    DateOfEnd = newEventFormViewModel.DateOfEnd,
                    Location = newEventFormViewModel.Location,
                    Tickets = newEventFormViewModel.Tickets,
                };
                _dbContext.Events.Add(events);
            }
            else
            {
                var eventInDb = _dbContext.Events.Single(e => e.Id == newEventFormViewModel.Id);
                eventInDb.Name = newEventFormViewModel.Name;
                eventInDb.Description = newEventFormViewModel.Description;
                eventInDb.Tickets = newEventFormViewModel.Tickets;
                eventInDb.DateOfStart = newEventFormViewModel.DateOfStart;
                eventInDb.DateOfEnd = newEventFormViewModel.DateOfEnd;
                eventInDb.Location = newEventFormViewModel.Location;

            }

            _dbContext.SaveChanges();
        }

        public void DeleteEvent(int Id)
        {
            var events = _dbContext.Events.FirstOrDefault(e => e.Id == Id);
            var ticket = _dbContext.Tickets.FirstOrDefault(t => t.Event.Id == Id);

            if (ticket != null)
            {
                _dbContext.Tickets.Remove(ticket);
            }

            _dbContext.Events.Remove(events);
            _dbContext.SaveChanges();
        }
        public EventFormViewModel EditEvent(int Id)
        {
            var events = GetEventId(Id);

            var viewModel = new EventFormViewModel
            {
                Id = events.Id,
                Name = events.Name,
                Description = events.Description,
                DateOfStart = events.DateOfStart,
                DateOfEnd = events.DateOfEnd,
                Location = events.Location,
                Tickets = events.Tickets,
            };
            return viewModel;
        }
    }
}
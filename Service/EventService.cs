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
        public Event GetNewEvent()
        {
            return new Event();
        }
        public IEnumerable<Event> GetEventList()
        {
            return _dbContext.Events.ToList();
        }

        public Event GetEventId(int Id)
        {
            return _dbContext.Events.FirstOrDefault(c => c.Id == Id);
        }

        public void SaveNewEditEvent(EventFormViewModel newEventFormViewModel)
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
    }
}
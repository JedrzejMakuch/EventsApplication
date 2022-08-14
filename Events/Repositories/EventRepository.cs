using EventsLibrary.Models;
using EventsLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Event> GetEvents()
        {
            return _dbContext.Events;
        }

        public Event EventId(int Id)
        {
            return _dbContext.Events.SingleOrDefault(c => c.Id == Id);
        }

        public void AddOrEditEvent(EventFormViewModel newEventFormViewModel)
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

        public void DeleteEvnt(int Id)
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

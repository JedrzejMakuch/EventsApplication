using EventsLibrary.Models;
using System.Linq;

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

        public void SaveEditEvent(Event Event)
        {
            if (Event.Id == 0)
            {
                _dbContext.Events.Add(Event);
            }
            else
            {
                var eventInDb = _dbContext.Events.Single(e => e.Id == Event.Id);
                eventInDb.Name = Event.Name;
                eventInDb.Description = Event.Description;
                eventInDb.Tickets = Event.Tickets;
                eventInDb.DateOfStart = Event.DateOfStart;
                eventInDb.DateOfEnd = Event.DateOfEnd;
                eventInDb.Location = Event.Location;
            }

            _dbContext.SaveChanges();
        }

        public void DeleteEvnt(int Id)
        {
            var events = _dbContext.Events.FirstOrDefault(e => e.Id == Id);
            var tickets = _dbContext.Tickets.Where(t => t.Event.Id == Id);

            if (tickets != null)
            {
                foreach(var t in tickets)
                {
                    _dbContext.Tickets.Remove(t);
                }
            }
            _dbContext.Events.Remove(events);
            _dbContext.SaveChanges();
        }
    }
}

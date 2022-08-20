using EventsLibrary.Models;
using System.Linq;

namespace Events.Repositories
{
    public interface IEventRepository
    {
        IQueryable<Event> GetEvents();

        Event EventId(int Id);

        void SaveEditEvent(Event Event);

        void DeleteEvnt(int Id);
    }
}

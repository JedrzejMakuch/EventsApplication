using EventsApplication.Services.Models;
using System.Collections.Generic;

namespace EventsApplication.Services.Abstractions
{
    public interface IEventService
    {
        EventModel GetEventById(int Id);
        IEnumerable<EventModel> GetEventList();
        void SaveEvent(EventModel EventModel);
        void DeleteEvent(int Id);
        EventModel EditEvent(int Id);
    }
}

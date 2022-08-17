using EventsApplication.Services.Models;
using System.Collections.Generic;

namespace EventsApplication.Services.Abstractions
{
    public interface IEventService
    {
        EventModel GetEventById(int Id);
        IEnumerable<EventModel> GetEventList();
        //void SaveNewEditEvent(EventFormViewModel newEventFormViewModel);
        //void DeleteEvent(int Id);
        //EventFormViewModel EditEvent(int Id);
    }
}

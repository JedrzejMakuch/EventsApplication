using EventsLibrary.Models;
using EventsLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsLibrary.Service
{
    public interface IEventService
    {
        Event GetEventId(int Id);
        IEnumerable<Event> GetEventList();
        void SaveNewEditEvent(EventFormViewModel newEventFormViewModel);
        void DeleteEvent(int Id);
        EventFormViewModel EditEvent(int Id);
    }
}

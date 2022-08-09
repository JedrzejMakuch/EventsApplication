using EventsApplication.Models;
using EventsApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApplication.Service
{
    public interface IEventService
    {
        Event GetEventId(int Id);
        IEnumerable<Event> GetEventList();
        Event GetNewEvent();
        void SaveNewEditEvent(EventFormViewModel newEventFormViewModel);
        void DeleteEvent(int Id);
    }
}

using EventsLibrary.Models;
using EventsLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Repositories
{
    public interface IEventRepository
    {
        IQueryable<Event> GetEvents();

        Event EventId(int Id);

        void AddOrEditEvent(EventFormViewModel newEventFormViewModel);

        void DeleteEvnt(int Id);
    }
}

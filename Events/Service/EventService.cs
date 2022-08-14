using Events.Repositories;
using EventsLibrary.Models;
using EventsLibrary.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace EventsLibrary.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
      
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IEnumerable<Event> GetEventList()
        {
            return _eventRepository.GetEvents().ToList();
        }

        public Event GetEventId(int Id)
        {
            return _eventRepository.EventId(Id);
        }

        

        public void SaveNewEditEvent(EventFormViewModel newEventFormViewModel)
        {
            _eventRepository.AddOrEditEvent(newEventFormViewModel);
        }

        

        public void DeleteEvent(int Id)
        {
            _eventRepository.DeleteEvnt(Id);
        }

        

        public EventFormViewModel EditEvent(int Id)
        {
            var events = _eventRepository.EventId(Id);

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
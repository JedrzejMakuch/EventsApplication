using Events.Repositories;
using EventsApplication.Services.Abstractions;
using EventsApplication.Services.Models;
using EventsLibrary.Models;
using EventsLibrary.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace EventsApplication.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
      
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IEnumerable<EventModel> GetEventList()
        {
            var dtos = _eventRepository.GetEvents().ToList();

            return dtos.Select(dto => new EventModel(
                dto.Id,
                dto.Name,
                dto.Description,
                dto.Location,
                dto.DateOfStart,
                dto.DateOfEnd,
                dto.Tickets));
        }

        public EventModel GetEventById(int Id)
        {
            var dto = _eventRepository.EventId(Id);
            return new EventModel(
                dto.Id,
                dto.Name,
                dto.Description,
                dto.Location,
                dto.DateOfStart,
                dto.DateOfEnd,
                dto.Tickets);
        }

        //public void SaveNewEditEvent(EventFormViewModel newEventFormViewModel)
        //{
        //    _eventRepository.AddOrEditEvent(newEventFormViewModel);
        //}

        

        //public void DeleteEvent(int Id)
        //{
        //    _eventRepository.DeleteEvnt(Id);
        //}

        

        //public EventFormViewModel EditEvent(int Id)
        //{
        //    var events = _eventRepository.EventId(Id);

        //    var viewModel = new EventFormViewModel
        //    {
        //        Id = events.Id,
        //        Name = events.Name,
        //        Description = events.Description,
        //        DateOfStart = events.DateOfStart,
        //        DateOfEnd = events.DateOfEnd,
        //        Location = events.Location,
        //        Tickets = events.Tickets,
        //    };
        //    return viewModel;
        //}
    }
}
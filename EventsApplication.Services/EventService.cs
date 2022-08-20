using Events.Repositories;
using EventsApplication.Services.Abstractions;
using EventsApplication.Services.Models;
using EventsLibrary.Models;
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

        public void SaveEvent(EventModel EventModel)
        {
            var events = new Event
            { 
                Id = EventModel.Id,
                Name = EventModel.Name,
                Description = EventModel.Description,
                Location = EventModel.Location,
                DateOfStart = EventModel.StartDate,
                DateOfEnd = EventModel.EndDate,
                Tickets = EventModel.TicketsLeft
            };
            _eventRepository.SaveEditEvent(events);
        }



        public void DeleteEvent(int Id)
        {
            _eventRepository.DeleteEvnt(Id);
        }



        public EventModel EditEvent(int Id)
        {
            var events = _eventRepository.EventId(Id);


            return new EventModel(
                events.Id,
                events.Name,
                events.Description,
                events.Location,
                events.DateOfStart,
                events.DateOfEnd,
                events.Tickets);
        }
            
    }
}
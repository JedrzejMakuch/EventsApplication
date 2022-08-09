using EventsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApplication.Service
{
    public class EventService
    {
        private readonly ApplicationDbContext _dbContext;

        public EventService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public Event GetEventId(int Id)
        {
            return _dbContext.Events.SingleOrDefault(c => c.Id == Id);
        }
    }
}
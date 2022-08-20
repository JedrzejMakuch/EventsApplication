using System;

namespace EventsApplication.Services.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string Description { get; set; }


        public string Location { get; set; }


        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }


        public int TicketsLeft { get; set; }

        public EventModel(
            int id,
            string name,
            string description,
            string location,
            DateTime startDate,
            DateTime endDate,
            int ticketsLeft)
        {
            Id = id;
            Name = name;
            Description = description;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
            TicketsLeft = ticketsLeft;
        }
    }
}

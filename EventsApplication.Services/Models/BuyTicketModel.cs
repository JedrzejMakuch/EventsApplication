using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApplication.Services.Models
{
    public class BuyTicketModel
    {
        public int EventId { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public BuyTicketModel(int eventId, string firstName, string lastName, string email)
        {
            EventId = eventId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}

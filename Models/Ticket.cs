using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsApplication.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        //public int CustomerId { get; set; }
        public Customer Customer { get; set; }
       // public int EventId { get; set; }
        public Event Event { get; set; }    

        
    }   
}
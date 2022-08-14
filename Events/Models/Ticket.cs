using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsLibrary.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Event Event { get; set; }    

        
    }   
}
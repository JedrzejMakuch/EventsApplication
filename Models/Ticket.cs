using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsApplication.Models
{
    public class Ticket
    {
        [Display(Name = "Ticket number")]
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Event Event { get; set; }    

        
    }   
}
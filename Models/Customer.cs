using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsApplication.Models
{
    public class Customer
    {
        [Display(Name = "Ticket number")]
        public int Id { get; set; }
  
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        
        [Display(Name = "Email adress")]
        public string Email { get; set; }
        
        public bool? IsRegistered { get; set; }

    }
}
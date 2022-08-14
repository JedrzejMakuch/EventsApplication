using EventsLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsLibrary.ViewModel
{
    public class BuyTicketFormViewModel
    {
        public int EventId { get; set; }    
        public Ticket Ticket { get; set; }

        public int CustomerId { get; set; } 


        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name ="Last name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Adress email is required.")]
        [Display(Name ="Adress email")]
        public string Email { get; set; }   
    }
}

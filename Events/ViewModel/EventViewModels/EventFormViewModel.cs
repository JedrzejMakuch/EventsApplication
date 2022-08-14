using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EventsLibrary.Models;



namespace EventsLibrary.ViewModel
{
    public class EventFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Event name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Date is required.")]
        [Display(Name = "Date of start")]
        public DateTime DateOfStart { get; set; }


        [Required(ErrorMessage = "Date is required.")]
        [Display(Name = "Date of end")]
        public DateTime DateOfEnd { get; set; }


        [Required(ErrorMessage = "Tickets are required.")]
        public int Tickets { get; set; }


        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace EventsApplication.ViewModels
{
    public class EventDetailsViewModel
    {
        public EventDetailsViewModel()
        {

        }
        public int Id { get; set; }



        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Event name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Date is required.")]
        [Display(Name = "Date of start")]
        public DateTime StartDate { get; set; }


        [Required(ErrorMessage = "Date is required.")]
        [Display(Name = "Date of end")]
        public DateTime EndDate { get; set; }


        [Required(ErrorMessage = "Tickets are required.")]
        public int TicketsLeft { get; set; }


        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        public EventDetailsViewModel(
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
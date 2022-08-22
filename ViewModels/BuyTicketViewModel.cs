using System.ComponentModel.DataAnnotations;

namespace EventsApplication.ViewModels
{
    public class BuyTicketViewModel
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Adress email is required.")]
        [Display(Name = "Adress email")]
        public string Email { get; set; }

    }

}
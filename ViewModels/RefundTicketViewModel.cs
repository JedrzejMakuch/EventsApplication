using System.ComponentModel.DataAnnotations;

namespace EventsApplication.ViewModels
{
    public class RefundTicketViewModel
    {
        public RefundTicketViewModel()
        {

        }

        [Required(ErrorMessage = "Ticket number is required")]
        [Display(Name = "Ticket number")]
        public int Id { get; set; }


        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adress email is required.")]
        [Display(Name = "Adress email")]
        public string Email { get; set; }

        public RefundTicketViewModel(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
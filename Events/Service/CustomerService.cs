using Events.Repositories;
using EventsLibrary.Models;
using EventsLibrary.ViewModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EventsLibrary.Service
{
    public class CustomerService : ICustomerService
    {
        public bool ValidateCustomer(ReturnTicketFormViewModel returnTicketFormViewModel, Ticket ticket)
        {
            return returnTicketFormViewModel.FirstName == ticket.Customer.FirstName &&
                   returnTicketFormViewModel.LastName == ticket.Customer.LastName &&
                   returnTicketFormViewModel.Email == ticket.Customer.Email;
        }

    }
}
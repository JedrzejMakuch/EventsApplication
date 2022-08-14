using EventsLibrary.Models;
using EventsLibrary.ViewModel;
using System.Collections.Generic;

namespace EventsLibrary.Service
{
    public interface ICustomerService
    {
        bool ValidateCustomer(ReturnTicketFormViewModel returnTicketFormViewModel, Ticket ticket);
    }
}

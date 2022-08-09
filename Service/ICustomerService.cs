using EventsApplication.Models;
using EventsApplication.ViewModel;
using System.Collections.Generic;

namespace EventsApplication.Service
{
    public interface ICustomerService
    {
        Customer GetNewCustomer();
        IEnumerable<Customer> GetCustomersList();
        Customer GetCustomerId(Customer Customer);
        bool ValidateCustomer(ReturnTicketFormViewModel returnTicketFormViewModel, Ticket ticket);
    }
}

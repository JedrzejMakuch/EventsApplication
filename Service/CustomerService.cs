using EventsApplication.Models;
using EventsApplication.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace EventsApplication.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;
      
        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer  GetNewCustomer()
        {
            return new Customer();
        }

        public IEnumerable<Customer> GetCustomersList()
        {
            return _dbContext.Customers.ToList();
        }
        public Customer GetCustomerId(Customer Customer)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Id == Customer.Id);
        }

        public bool ValidateCustomer(ReturnTicketFormViewModel returnTicketFormViewModel, Ticket ticket)
        {
            return returnTicketFormViewModel.FirstName == ticket.Customer.FirstName &&
                   returnTicketFormViewModel.LastName == ticket.Customer.LastName &&
                   returnTicketFormViewModel.Email == ticket.Customer.Email;
        }

    
    }
}
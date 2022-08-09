using EventsApplication.Models;
using EventsApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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
            return returnTicketFormViewModel.Customer.FirstName == ticket.Customer.FirstName &&
                            returnTicketFormViewModel.Customer.LastName == ticket.Customer.LastName &&
                            returnTicketFormViewModel.Customer.Email == ticket.Customer.Email;
        }

    
    }
}
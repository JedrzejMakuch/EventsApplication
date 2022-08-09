using EventsApplication.Models;
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

        public bool CheckCustomerEFNLN(Customer Customer)
        {
            return GetCustomerId(Customer).Email == Customer.Email &&
                   GetCustomerId(Customer).FirstName == Customer.FirstName &&
                   GetCustomerId(Customer).LastName == Customer.LastName;
        }

        public void SaveData()
        {
             _dbContext.SaveChanges();
        }

        //public EntityState RemoveCustomer(Customer Customer)
        //{
        //    return _dbContext.Entry(Customer).State = EntityState.Deleted;
        //}

        public Customer AddNewCustomer(Customer customer)
        {
            return _dbContext.Customers.Add(customer);
        }
    }
}
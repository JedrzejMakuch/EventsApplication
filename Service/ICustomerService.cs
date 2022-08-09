using EventsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApplication.Service
{
    public interface ICustomerService
    {
        Customer GetNewCustomer();
        IEnumerable<Customer> GetCustomersList();
    }
}

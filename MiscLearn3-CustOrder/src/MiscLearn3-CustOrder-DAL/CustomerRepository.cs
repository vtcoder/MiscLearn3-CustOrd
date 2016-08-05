using MiscLearn3_CustOrder_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder_DAL
{
    public class CustomerRepository
    {
        public CustomerRepository()
        {
        }

        public List<Customer> GetAllCustomers()
        {
            ///TEMP return fake test data
            return new List<Customer>()
            {
                new Customer() { FirstName = "John", LastName = "Doe" },
                new Customer() { FirstName = "Frank", LastName = "Doe" },
                new Customer() { FirstName = "Will", LastName = "Doe" }
            };
        }
    }
}

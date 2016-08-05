using MiscLearn3_CustOrder_BE;
using MiscLearn3_CustOrder_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder_BL
{
    public class CustomerManager
    {
        public CustomerManager()
        {
        }

        public List<Customer> GetAllCustomers()
        {
            CustomerRepository customerRepo = new CustomerRepository();
            var customers = customerRepo.GetAllCustomers();
            return customers;
        }
    }
}

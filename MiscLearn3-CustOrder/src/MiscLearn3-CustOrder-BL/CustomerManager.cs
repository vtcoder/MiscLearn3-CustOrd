﻿using MiscLearn3_CustOrder_BE;
using MiscLearn3_CustOrder_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder_BL
{
    public class CustomerManager
    {
        private string _connectionString;

        public CustomerManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Customer> GetAllCustomers()
        {
            CustomerRepository customerRepo = new CustomerRepository(_connectionString);
            var customers = customerRepo.GetAllCustomers();
            return customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            CustomerRepository customerRepo = new CustomerRepository(_connectionString);
            var customer = customerRepo.GetById(customerId);
            return customer;
        }

        public void Add(Customer customer)
        {
            CustomerRepository customerRepo = new CustomerRepository(_connectionString);
            customerRepo.Add(customer);
        }

        public void Edit(Customer customer)
        {
            CustomerRepository customerRepo = new CustomerRepository(_connectionString);
            customerRepo.Edit(customer);
        }
    }
}

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

        public void Delete(int customerId)
        {
            CustomerRepository customerRepo = new CustomerRepository(_connectionString);
            customerRepo.Delete(customerId);
        }

        public List<CustomerExtensionField> GetExtensionFieldsForAllCustomers()
        {
            CustomerRepository customerRepo = new CustomerRepository(_connectionString);
            var customerExtensionFields = customerRepo.GetExtensionFieldsForAllCustomers();
            return customerExtensionFields;
        }

        public List<CustomerExtensionField> GetExtensionFieldsForCustomer(int customerId)
        {
            CustomerRepository customerRepo = new CustomerRepository(_connectionString);
            var customerExtensionFields = customerRepo.GetExtensionFieldsForCustomer(customerId);
            return customerExtensionFields;
        }

        public void AddCustomerExtensionFieldForAllCustomers(ExtensionFieldDefinition extensionFieldDefinition)
        {
            CustomerRepository customerRepo = new CustomerRepository(_connectionString);
            customerRepo.AddCustomerExtensionFieldForAllCustomers(extensionFieldDefinition);
        }

        public void AddCustomerExtensionField(CustomerExtensionField customerExtensionField)
        {
            CustomerRepository customerRepo = new CustomerRepository(_connectionString);
            customerRepo.AddCustomerExtensionField(customerExtensionField);
        }

        public void EditCustomerExtensionField(CustomerExtensionField customerExtensionField)
        {
            CustomerRepository customerRepo = new CustomerRepository(_connectionString);
            customerRepo.EditCustomerExtensionField(customerExtensionField);
        }
    }
}

using MiscLearn3_CustOrder_BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder_DAL
{
    public class CustomerRepository
    {
        private const string GET_ALL = "CustomersGetAll";

        private string _connectionString;

        public CustomerRepository(string connectionString)
            : base()
        {
            _connectionString = connectionString;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(GET_ALL, conn))
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.NextResult())
                {
                    Customer customer = new Customer();
                    customer.Id = Convert.ToInt32(reader[0]);
                    customer.FirstName = reader[1].ToString();
                    customer.LastName = reader[2].ToString();
                    customers.Add(customer);
                }
            }

            return customers;
        }
    }
}

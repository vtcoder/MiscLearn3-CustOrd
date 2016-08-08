using MiscLearn3_CustOrder_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder_DAL
{
    public class CustomerRepository
    {
        private const string GET_ALL = "dbo.CustomersGetAll";
        private const string ADD = "dbo.CustomerAdd";

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
            using (SqlCommand cmd = new SqlCommand(GET_ALL, conn) { CommandType = CommandType.StoredProcedure })
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
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

        public void Add(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(ADD, conn) { CommandType = CommandType.StoredProcedure })
            {
                conn.Open();
                var idParam = new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output, ParameterName = "CustomerId" };
                cmd.Parameters.Add(idParam);
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, ParameterName = "FirstName", Value = customer.FirstName });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, ParameterName = "LastName", Value = customer.LastName });

                int recordsUpdated = cmd.ExecuteNonQuery();
                
                customer.Id = Convert.ToInt32(idParam.Value);
            }
        }
    }
}

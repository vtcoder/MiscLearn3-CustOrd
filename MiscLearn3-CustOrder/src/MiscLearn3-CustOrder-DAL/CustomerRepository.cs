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
        private const string GET_BY_ID = "dbo.CustomersGetById";
        private const string ADD = "dbo.CustomerAdd";
        private const string EDIT = "dbo.CustomerEdit";
        private const string DELETE = "dbo.CustomerDelete";

        private const string GET_CUST_EXT_FLD_BY_ALL_CUSTOMERS = "dbo.CustomerExtensionFieldGetByAllCustomers";
        private const string GET_CUST_EXT_FLD_BY_CUSTOMER = "dbo.CustomerExtensionFieldGetByCustomer";
        private const string ADD_CUST_EXT_FLD_TO_ALL_CUSTOMERS = "dbo.CustomerExtensionFieldAddForAllCustomers";
        private const string ADD_CUST_EXT_FLD = "dbo.CustomerExtensionFieldAdd";
        private const string EDIT_CUST_EXT_FLD = "dbo.CustomerExtensionFieldEdit";

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

        public Customer GetById(int customerID)
        {
            Customer customer = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(GET_BY_ID, conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "CustomerId", Value = customerID });

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer = new Customer();
                    customer.Id = Convert.ToInt32(reader[0]);
                    customer.FirstName = reader[1].ToString();
                    customer.LastName = reader[2].ToString();
                }
            }

            return customer;
        }

        public void Add(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(ADD, conn) { CommandType = CommandType.StoredProcedure })
            {                
                var idParam = new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output, ParameterName = "CustomerId" };
                cmd.Parameters.Add(idParam);
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, ParameterName = "FirstName", Value = customer.FirstName });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, ParameterName = "LastName", Value = customer.LastName });

                conn.Open();
                cmd.ExecuteNonQuery();
                
                customer.Id = Convert.ToInt32(idParam.Value);
            }
        }

        public void Edit(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(EDIT, conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "CustomerId", Value = customer.Id });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, ParameterName = "FirstName", Value = customer.FirstName });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, ParameterName = "LastName", Value = customer.LastName });

                conn.Open();
                int recordsUpdated = cmd.ExecuteNonQuery();

                if (recordsUpdated != 1)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Delete(int customerID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(DELETE, conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "CustomerId", Value = customerID });

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<CustomerExtensionField> GetExtensionFieldsForAllCustomers()
        {
            List<CustomerExtensionField> customerExtensionFields = new List<CustomerExtensionField>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(GET_CUST_EXT_FLD_BY_ALL_CUSTOMERS, conn) { CommandType = CommandType.StoredProcedure })
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerExtensionField customerExtensionField = new CustomerExtensionField();
                    customerExtensionField.Id = Convert.ToInt32(reader[0]);
                    customerExtensionField.CustomerId = Convert.ToInt32(reader[1]);
                    customerExtensionField.Value = reader.IsDBNull(2) ? null : reader[2].ToString();

                    customerExtensionField.Definition.Id = Convert.ToInt32(reader[3]);
                    customerExtensionField.Definition.Name = reader[4].ToString();
                    customerExtensionField.Definition.EntityType = (EntityType)Enum.Parse(typeof(EntityType), reader[5].ToString());
                    customerExtensionField.Definition.DataType = (ExtensionFieldDataType)Enum.Parse(typeof(ExtensionFieldDataType), reader[6].ToString());

                    customerExtensionFields.Add(customerExtensionField);
                }
            }

            return customerExtensionFields;
        }

        public List<CustomerExtensionField> GetExtensionFieldsForCustomer(int customerId)
        {
            List<CustomerExtensionField> customerExtensionFields = new List<CustomerExtensionField>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(GET_CUST_EXT_FLD_BY_CUSTOMER, conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "CustomerId", Value = customerId });

                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerExtensionField customerExtensionField = new CustomerExtensionField();
                    customerExtensionField.Id = Convert.ToInt32(reader[0]);
                    customerExtensionField.CustomerId = Convert.ToInt32(reader[1]);
                    customerExtensionField.Value = reader.IsDBNull(2) ? null : reader[2].ToString();

                    customerExtensionField.Definition.Id = Convert.ToInt32(reader[3]);
                    customerExtensionField.Definition.Name = reader[4].ToString();
                    customerExtensionField.Definition.EntityType = (EntityType)Enum.Parse(typeof(EntityType), reader[5].ToString());
                    customerExtensionField.Definition.DataType = (ExtensionFieldDataType)Enum.Parse(typeof(ExtensionFieldDataType), reader[6].ToString());

                    customerExtensionFields.Add(customerExtensionField);
                }
            }

            return customerExtensionFields;
        }

        public void AddCustomerExtensionFieldForAllCustomers(ExtensionFieldDefinition extensionFieldDefinition)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(ADD_CUST_EXT_FLD_TO_ALL_CUSTOMERS, conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "ExtensionFieldDefinitionID", Value = extensionFieldDefinition.Id });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "EntityType", Value = EntityType.Customer});
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, ParameterName = "DefaultValue", Value = extensionFieldDefinition.DefaultValue });

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddCustomerExtensionField(CustomerExtensionField customerExtensionField)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(ADD_CUST_EXT_FLD, conn) { CommandType = CommandType.StoredProcedure })
            {
                var idParam = new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output, ParameterName = "CustomerExtensionFieldId" };
                cmd.Parameters.Add(idParam);
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "CustomerId", Value = customerExtensionField.CustomerId });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "ExtensionFieldDefinitionID", Value = customerExtensionField.Definition.Id });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "EntityType", Value = EntityType.Customer });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, ParameterName = "Value", Value = customerExtensionField.Value });

                conn.Open();
                cmd.ExecuteNonQuery();

                customerExtensionField.Id = Convert.ToInt32(idParam.Value);
            }
        }

        public void EditCustomerExtensionField(CustomerExtensionField customerExtensionField)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(EDIT_CUST_EXT_FLD, conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "CustomerId", Value = customerExtensionField.CustomerId });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "ExtensionFieldDefinitionId", Value = customerExtensionField.Definition.Id });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, ParameterName = "Value", Value = customerExtensionField.Value });

                conn.Open();
                int recordsUpdated = cmd.ExecuteNonQuery();
            }
        }
    }
}

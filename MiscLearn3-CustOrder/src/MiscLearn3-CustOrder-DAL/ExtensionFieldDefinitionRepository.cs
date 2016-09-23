using MiscLearn3_CustOrder_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder_DAL
{
    public class ExtensionFieldDefinitionRepository
    {
        private const string GET_ALL = "dbo.ExtensionFieldDefinitionsGetAll";
        private const string GET_BY_ID = "dbo.ExtensionFieldDefinitionGetById";
        private const string ADD = "dbo.ExtensionFieldDefinitionAdd";
        private const string EDIT = "dbo.ExtensionFieldDefinitionEdit";
        private const string DELETE = "dbo.ExtensionFieldDefinitionDelete";

        private string _connectionString;

        public ExtensionFieldDefinitionRepository(string connectionString)
            : base()
        {
            _connectionString = connectionString;
        }

        public List<ExtensionFieldDefinition> GetAllExtensionFields()
        {
            List<ExtensionFieldDefinition> extensionFields = new List<ExtensionFieldDefinition>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(GET_ALL, conn) { CommandType = CommandType.StoredProcedure })
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExtensionFieldDefinition extensionField = new ExtensionFieldDefinition();
                    extensionField.Id = Convert.ToInt32(reader[0]);
                    extensionField.Name = reader[1].ToString();
                    extensionField.EntityType = (EntityType)Enum.Parse(typeof(EntityType),  reader[2].ToString());
                    extensionField.DataType = (ExtensionFieldDataType)Enum.Parse(typeof(ExtensionFieldDataType), reader[3].ToString());
                    extensionFields.Add(extensionField);
                }
            }

            return extensionFields;
        }

        public ExtensionFieldDefinition GetById(int extensionFieldDefinitionID)
        {
            ExtensionFieldDefinition extensionFieldDefinition = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(GET_BY_ID, conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "ExtensionFieldDefinitionId", Value = extensionFieldDefinitionID });

                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    extensionFieldDefinition = new ExtensionFieldDefinition();
                    extensionFieldDefinition.Id = Convert.ToInt32(reader[0]);
                    extensionFieldDefinition.Name = reader[1].ToString();
                    extensionFieldDefinition.EntityType = (EntityType)Enum.Parse(typeof(EntityType), reader[2].ToString());
                    extensionFieldDefinition.DataType = (ExtensionFieldDataType)Enum.Parse(typeof(ExtensionFieldDataType), reader[3].ToString());
                }
            }

            return extensionFieldDefinition;
        }

        public void Add(ExtensionFieldDefinition extensionFieldDefinition)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(ADD, conn) { CommandType = CommandType.StoredProcedure })
            {
                var idParam = new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output, ParameterName = "ExtensionFieldDefinitionId" };
                cmd.Parameters.Add(idParam);
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, ParameterName = "Name", Value = extensionFieldDefinition.Name });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "EntityType", Value = extensionFieldDefinition.EntityType });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "DataType", Value = extensionFieldDefinition.DataType });

                conn.Open();
                cmd.ExecuteNonQuery();

                extensionFieldDefinition.Id = Convert.ToInt32(idParam.Value);
            }
        }

        public void Edit(ExtensionFieldDefinition extensionFieldDefinition)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(EDIT, conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "ExtensionFieldDefinitionId", Value = extensionFieldDefinition.Id });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Direction = ParameterDirection.Input, ParameterName = "Name", Value = extensionFieldDefinition.Name });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "EntityType", Value = extensionFieldDefinition.EntityType });
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "DataType", Value = extensionFieldDefinition.DataType });

                conn.Open();
                int recordsUpdated = cmd.ExecuteNonQuery();

                if (recordsUpdated != 1)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Delete(int extensionFieldDefinitionID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(DELETE, conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, ParameterName = "ExtensionFieldDefinitionId", Value = extensionFieldDefinitionID });

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

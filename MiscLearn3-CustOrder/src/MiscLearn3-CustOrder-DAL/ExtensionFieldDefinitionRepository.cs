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
    }
}

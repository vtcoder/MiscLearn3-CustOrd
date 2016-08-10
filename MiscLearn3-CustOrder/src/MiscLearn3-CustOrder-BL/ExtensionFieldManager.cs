using MiscLearn3_CustOrder_BE;
using MiscLearn3_CustOrder_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder_BL
{

    public class ExtensionFieldManager
    {
        private string _connectionString;

        public ExtensionFieldManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ExtensionFieldDefinition> GetAllExtensionFields()
        {
            ExtensionFieldDefinitionRepository extFldDefinitionRepo = new ExtensionFieldDefinitionRepository(_connectionString);
            var extensionFields = extFldDefinitionRepo.GetAllExtensionFields();
            return extensionFields;
        }
    }
}

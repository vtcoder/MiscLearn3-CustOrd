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

        public ExtensionFieldDefinition GetById(int extensionFieldDefinitionID)
        {
            ExtensionFieldDefinitionRepository extFldDefinitionRepo = new ExtensionFieldDefinitionRepository(_connectionString);
            var extensionField = extFldDefinitionRepo.GetById(extensionFieldDefinitionID);
            return extensionField;
        }

        public void Add(ExtensionFieldDefinition extensionFieldDefinition)
        {
            ExtensionFieldDefinitionRepository extFldDefinitionRepo = new ExtensionFieldDefinitionRepository(_connectionString);
            extFldDefinitionRepo.Add(extensionFieldDefinition);
        }

        public void Edit(ExtensionFieldDefinition extensionFieldDefinition)
        {
            ExtensionFieldDefinitionRepository extFldDefinitionRepo = new ExtensionFieldDefinitionRepository(_connectionString);
            extFldDefinitionRepo.Edit(extensionFieldDefinition);
        }

        public void Delete(int extensionFieldDefinitionID)
        {
            ExtensionFieldDefinitionRepository extFldDefinitionRepo = new ExtensionFieldDefinitionRepository(_connectionString);
            extFldDefinitionRepo.Delete(extensionFieldDefinitionID);
        }
    }
}

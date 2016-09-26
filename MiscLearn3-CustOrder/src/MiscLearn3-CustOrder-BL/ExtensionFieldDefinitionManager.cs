using MiscLearn3_CustOrder_BE;
using MiscLearn3_CustOrder_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder_BL
{

    public class ExtensionFieldDefinitionManager
    {
        private string _connectionString;

        public ExtensionFieldDefinitionManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ExtensionFieldDefinition> GetAllExtensionFieldDefinitions()
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
            
            if(extensionFieldDefinition.EntityType == EntityType.Customer)
            {
                CustomerManager customerManager = new CustomerManager(_connectionString);
                customerManager.AddNewExtensionFieldDefinition(extensionFieldDefinition);
            }
            else if(extensionFieldDefinition.EntityType == EntityType.Order)
            {
                throw new NotImplementedException();
            }
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

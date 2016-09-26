using MiscLearn3_CustOrder_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder.Models
{
    public static class ViewModelExtensions
    {
        public static CustomerExtensionFieldViewModel ToViewModel(this CustomerExtensionField customerExtensionField)
        {
            CustomerExtensionFieldViewModel viewModel = new CustomerExtensionFieldViewModel();
            viewModel.Id = customerExtensionField.Id;
            viewModel.CustomerId = customerExtensionField.CustomerId;
            viewModel.Value = customerExtensionField.Value;

            //ExtensionFieldDefinitionViewModel extFldViewModel = new ExtensionFieldDefinitionViewModel();
            viewModel.Definition.Id = customerExtensionField.Definition.Id;
            viewModel.Definition.Name = customerExtensionField.Definition.Name;
            viewModel.Definition.DataType = customerExtensionField.Definition.DataType;
            viewModel.Definition.EntityType = customerExtensionField.Definition.EntityType;

            return viewModel;
        }

        public static List<CustomerExtensionFieldViewModel> ToViewModel(this List<CustomerExtensionField> customerExtensionFields)
        {
            List<CustomerExtensionFieldViewModel> viewModels = new List<CustomerExtensionFieldViewModel>();
            foreach (var custExtFld in customerExtensionFields)
                viewModels.Add(custExtFld.ToViewModel());
            return viewModels;
        }

        public static ExtensionFieldDefinitionViewModel ToViewModel(this ExtensionFieldDefinition extensionFieldDefinition)
        {
            ExtensionFieldDefinitionViewModel viewModel = new ExtensionFieldDefinitionViewModel();
            viewModel.Id = extensionFieldDefinition.Id;
            viewModel.DataType = extensionFieldDefinition.DataType;
            viewModel.EntityType = extensionFieldDefinition.EntityType;
            viewModel.DefaultValue = extensionFieldDefinition.DefaultValue;
            viewModel.Name = extensionFieldDefinition.Name;

            return viewModel;
        }

        public static List<ExtensionFieldDefinitionViewModel> ToViewModel(this List<ExtensionFieldDefinition> extensionFieldDefinitions)
        {
            List<ExtensionFieldDefinitionViewModel> viewModels = new List<ExtensionFieldDefinitionViewModel>();
            foreach (var extensionFieldDefinition in extensionFieldDefinitions)
                viewModels.Add(extensionFieldDefinition.ToViewModel());
            return viewModels;
        }
    }
}

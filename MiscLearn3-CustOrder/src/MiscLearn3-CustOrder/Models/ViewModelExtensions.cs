using MiscLearn3_CustOrder_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder.Models
{
    public static class ViewModelExtensions
    {
        #region Customer Conversions

        public static CustomerViewModel ToViewModel(this Customer customer)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Id = customer.Id;
            customerViewModel.FirstName = customer.FirstName;
            customerViewModel.LastName = customer.LastName;

            return customerViewModel;
        }

        public static List<CustomerViewModel> ToViewModel(this List<Customer> customers)
        {
            List<CustomerViewModel> viewModels = new List<CustomerViewModel>();
            foreach (var cust in customers)
                viewModels.Add(cust.ToViewModel());
            return viewModels;
        }

        public static Customer ToEntity(this CustomerViewModel customerViewModel)
        {
            Customer customer = new Customer();
            customer.Id = customerViewModel.Id;
            customer.FirstName = customerViewModel.FirstName;
            customer.LastName = customerViewModel.LastName;

            return customer;
        }

        public static List<Customer> ToEntity(this List<CustomerViewModel> customerViewModels)
        {
            List<Customer> entities = new List<Customer>();
            foreach (var custViewModel in customerViewModels)
                entities.Add(custViewModel.ToEntity());
            return entities;
        }

        #endregion

        #region CustomerExtensionField Conversions

        public static CustomerExtensionFieldViewModel ToViewModel(this CustomerExtensionField customerExtensionField)
        {
            CustomerExtensionFieldViewModel viewModel = new CustomerExtensionFieldViewModel();
            viewModel.Id = customerExtensionField.Id;
            viewModel.CustomerId = customerExtensionField.CustomerId;
            viewModel.Value = customerExtensionField.Value;

            viewModel.Definition = customerExtensionField.Definition.ToViewModel();
            
            return viewModel;
        }

        public static List<CustomerExtensionFieldViewModel> ToViewModel(this List<CustomerExtensionField> customerExtensionFields)
        {
            List<CustomerExtensionFieldViewModel> viewModels = new List<CustomerExtensionFieldViewModel>();
            foreach (var custExtFld in customerExtensionFields)
                viewModels.Add(custExtFld.ToViewModel());
            return viewModels;
        }

        public static CustomerExtensionField ToEntity(this CustomerExtensionFieldViewModel customerExtensionFieldViewModel)
        {
            CustomerExtensionField customerExtensionField = new CustomerExtensionField();
            customerExtensionField.Id = customerExtensionFieldViewModel.Id;
            customerExtensionField.CustomerId = customerExtensionFieldViewModel.CustomerId;
            customerExtensionField.Value = customerExtensionFieldViewModel.Value;

            customerExtensionField.Definition = customerExtensionFieldViewModel.Definition.ToEntity();

            return customerExtensionField;
        }

        public static List<CustomerExtensionField> ToEntity(this List<CustomerExtensionFieldViewModel> customerExtensionFieldViewModels)
        {
            List<CustomerExtensionField> entities = new List<CustomerExtensionField>();
            foreach (var custExtFldViewModel in customerExtensionFieldViewModels)
                entities.Add(custExtFldViewModel.ToEntity());
            return entities;
        }

        #endregion

        #region ExtensionFieldDefintion Conversions

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

        public static ExtensionFieldDefinition ToEntity(this ExtensionFieldDefinitionViewModel extensionFieldDefinitionViewModel)
        {
            ExtensionFieldDefinition extensionFieldDefinition = new ExtensionFieldDefinition();
            extensionFieldDefinition.Id = extensionFieldDefinitionViewModel.Id;
            extensionFieldDefinition.DataType = extensionFieldDefinitionViewModel.DataType;
            extensionFieldDefinition.DefaultValue = extensionFieldDefinitionViewModel.DefaultValue;
            extensionFieldDefinition.EntityType = extensionFieldDefinitionViewModel.EntityType;
            extensionFieldDefinition.Name = extensionFieldDefinitionViewModel.Name;

            return extensionFieldDefinition;
        }

        public static List<ExtensionFieldDefinition> ToEntity(this List<ExtensionFieldDefinitionViewModel> extensionFieldDefinitionViewModels)
        {
            List<ExtensionFieldDefinition> entities = new List<ExtensionFieldDefinition>();
            foreach (var extensionFieldDefinitionViewModel in extensionFieldDefinitionViewModels)
                entities.Add(extensionFieldDefinitionViewModel.ToEntity());
            return entities;
        }

        #endregion
    }
}

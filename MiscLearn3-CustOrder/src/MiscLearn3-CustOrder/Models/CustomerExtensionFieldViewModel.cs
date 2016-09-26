using MiscLearn3_CustOrder_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder.Models
{
    public class CustomerExtensionFieldViewModel
    {
        public CustomerExtensionFieldViewModel()
            : base()
        {
            Definition = new ExtensionFieldDefinitionViewModel();
        }

        public int Id { get; set; }
        public string Value { get; set; }
        public int CustomerId { get; set; }
        public ExtensionFieldDefinitionViewModel Definition { get; set; }
    }

    public static class Extensions
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
    }
}

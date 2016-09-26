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
}

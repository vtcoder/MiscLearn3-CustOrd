using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder_BE
{
    public class CustomerExtensionField
    {
        public CustomerExtensionField()
            : base()
        {
            Definition = new ExtensionFieldDefinition();
        }

        public int Id { get; set; }
        public string Value { get; set; }
        public int CustomerId { get; set; }
        public ExtensionFieldDefinition Definition { get; set; }
    }
}

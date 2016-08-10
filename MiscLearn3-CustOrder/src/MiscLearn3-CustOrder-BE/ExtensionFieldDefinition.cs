using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder_BE
{
    public class ExtensionFieldDefinition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EntityType EntityType { get; set; }
        public ExtensionFieldDataType DataType { get; set; }
    }
}

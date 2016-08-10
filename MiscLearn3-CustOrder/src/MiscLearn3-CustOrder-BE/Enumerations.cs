using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder_BE
{
    public enum EntityType
    {
        Customer = 0,
        Order = 1
    }

    public enum ExtensionFieldDataType
    {
        Integer = 0,
        Decimal = 1,
        Text = 2,
        Date = 3
    }
}

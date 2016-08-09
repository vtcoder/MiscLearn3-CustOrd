using Microsoft.AspNetCore.Mvc;
using MiscLearn3_CustOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder.Components.Customer
{
    public class CustomerTableRowViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CustomerViewModel customerViewModel, bool isHeader = false)
        {
            return View(new Tuple<CustomerViewModel, bool>(customerViewModel, isHeader));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MiscLearn3_CustOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder.Components.Customer
{
    public class CustomerFormFieldsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CustomerViewModel customerViewModel)
        {
            return View(customerViewModel);
        }
    }
}

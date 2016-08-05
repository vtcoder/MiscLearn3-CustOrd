using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiscLearn3_CustOrder.Models;
using MiscLearn3_CustOrder_BL;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MiscLearn3_CustOrder.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            CustomerManager customerManager = new CustomerManager();

            var customers = customerManager.GetAllCustomers();

            List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();
            foreach (var customer in customers)
            {
                customerViewModels.Add(new CustomerViewModel()
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                });
            }

            return View(customerViewModels);
        }
    }
}

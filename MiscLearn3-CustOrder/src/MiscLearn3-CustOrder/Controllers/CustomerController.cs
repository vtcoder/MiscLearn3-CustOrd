using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiscLearn3_CustOrder.Models;
using MiscLearn3_CustOrder_BL;
using Microsoft.Extensions.Options;
using MiscLearn3_CustOrder.Models.Settings;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MiscLearn3_CustOrder.Controllers
{
    public class CustomerController : Controller
    {
        private MyAppSettings _appSettings;

        public CustomerController(IOptions<MyAppSettings> appSettings)
            : base()
        {
            _appSettings = appSettings.Value;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            CustomerManager customerManager = new CustomerManager(_appSettings.DefaultConnection);

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

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(CustomerViewModel customerViewModel)
        {
            return RedirectToAction("Index");
        }
    }
}

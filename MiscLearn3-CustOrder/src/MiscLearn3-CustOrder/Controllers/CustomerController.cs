using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiscLearn3_CustOrder.Models;
using MiscLearn3_CustOrder_BL;
using Microsoft.Extensions.Options;
using MiscLearn3_CustOrder.Models.Settings;
using MiscLearn3_CustOrder_BE;

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
                    Id = customer.Id,
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
            Customer customer = new Customer();
            customer.FirstName = customerViewModel.FirstName;
            customer.LastName = customerViewModel.LastName;

            CustomerManager customerManager = new CustomerManager(_appSettings.DefaultConnection);
            customerManager.Add(customer);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int customerId)
        {
            CustomerManager customerManager = new CustomerManager(_appSettings.DefaultConnection);
            Customer customer = customerManager.GetCustomerById(customerId);

            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

            return View("Edit", customerViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CustomerViewModel customerViewModel)
        {
            Customer customer = new Customer();
            customer.Id = customerViewModel.Id;
            customer.FirstName = customerViewModel.FirstName;
            customer.LastName = customerViewModel.LastName;

            CustomerManager customerManager = new CustomerManager(_appSettings.DefaultConnection);
            customerManager.Edit(customer);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CancelAddOrEdit()
        {
            return Index();
        }
    }
}

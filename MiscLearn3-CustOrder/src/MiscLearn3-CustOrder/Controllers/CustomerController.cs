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
            ExtensionFieldDefinitionManager extFldManager = new ExtensionFieldDefinitionManager(_appSettings.DefaultConnection);

            var customers = customerManager.GetAllCustomers();
            var customerExtFlds = customerManager.GetExtensionFieldsForAllCustomers();

            List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();
            foreach (var customer in customers)
            {
                customerViewModels.Add(new CustomerViewModel()
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    ExtensionFields = customerExtFlds.Where(cef => cef.CustomerId == customer.Id).OrderBy(cef => cef.Definition.Id).ToList().ToViewModel()
                });
            }

            return View(customerViewModels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ExtensionFieldDefinitionManager extFldManager = new ExtensionFieldDefinitionManager(_appSettings.DefaultConnection);
            var extFldDefs = extFldManager.GetAllExtensionFieldDefinitions().Where(ef => ef.EntityType == EntityType.Customer).ToList();
            var custExtFlds = extFldDefs.Select(efd => new CustomerExtensionFieldViewModel() { Id = -1, CustomerId = -1, Value = null, Definition = efd.ToViewModel() }).ToList();

            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                Id = -1,
                FirstName = string.Empty,
                LastName = string.Empty,
                ExtensionFields = custExtFlds
            };

            return View("Add", customerViewModel);
        }

        [HttpPost]
        public IActionResult Add(CustomerViewModel customerViewModel)
        {
            Customer customer = new Customer();
            customer.FirstName = customerViewModel.FirstName;
            customer.LastName = customerViewModel.LastName;

            CustomerManager customerManager = new CustomerManager(_appSettings.DefaultConnection);
            customerManager.Add(customer);

            //TODO add logic to save cust ext fld values for add new customer action

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

        [HttpGet]
        public IActionResult Delete(int customerId)
        {
            CustomerManager customerManager = new CustomerManager(_appSettings.DefaultConnection);
            customerManager.Delete(customerId);

            return RedirectToAction("Index");
        }
    }
}

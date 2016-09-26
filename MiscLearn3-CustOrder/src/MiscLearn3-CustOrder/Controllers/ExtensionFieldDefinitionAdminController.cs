using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiscLearn3_CustOrder_BL;
using MiscLearn3_CustOrder.Models.Settings;
using Microsoft.Extensions.Options;
using MiscLearn3_CustOrder.Models;
using MiscLearn3_CustOrder_BE;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MiscLearn3_CustOrder.Controllers
{
    public class ExtensionFieldDefinitionAdminController : Controller
    {
        private MyAppSettings _appSettings;

        public ExtensionFieldDefinitionAdminController(IOptions<MyAppSettings> appSettings)
            : base()
        {
            _appSettings = appSettings.Value;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ExtensionFieldDefinitionManager extensionFieldManager = new ExtensionFieldDefinitionManager(_appSettings.DefaultConnection);
            var extensionFieldDefinitions = extensionFieldManager.GetAllExtensionFieldDefinitions();

            List<ExtensionFieldDefinitionViewModel> extensionFieldDefinitionViewModels = new List<ExtensionFieldDefinitionViewModel>();
            foreach(var extFldDef in extensionFieldDefinitions)
            {
                extensionFieldDefinitionViewModels.Add(new ExtensionFieldDefinitionViewModel()
                {
                    Id = extFldDef.Id,
                    Name = extFldDef.Name,
                    EntityType = extFldDef.EntityType,
                    DataType = extFldDef.DataType,
                    DefaultValue = extFldDef.DefaultValue
                });
            }

            return View(extensionFieldDefinitionViewModels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(ExtensionFieldDefinitionViewModel extensionFieldDefinitionViewModel)
        {
            ExtensionFieldDefinition extensionFieldDefinition = new ExtensionFieldDefinition();
            extensionFieldDefinition.Name = extensionFieldDefinitionViewModel.Name;
            extensionFieldDefinition.EntityType = extensionFieldDefinitionViewModel.EntityType;
            extensionFieldDefinition.DataType = extensionFieldDefinitionViewModel.DataType;
            extensionFieldDefinition.DefaultValue = extensionFieldDefinitionViewModel.DefaultValue;

            ExtensionFieldDefinitionManager extensionFieldManager = new ExtensionFieldDefinitionManager(_appSettings.DefaultConnection);
            extensionFieldManager.Add(extensionFieldDefinition);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int extensionFieldDefinitionId)
        {
            ExtensionFieldDefinitionManager extensionFieldManager = new ExtensionFieldDefinitionManager(_appSettings.DefaultConnection);
            ExtensionFieldDefinition extensionFieldDefinition = extensionFieldManager.GetById(extensionFieldDefinitionId);

            ExtensionFieldDefinitionViewModel extensionFieldDefinitionViewModel = new ExtensionFieldDefinitionViewModel()
            {
                Id = extensionFieldDefinition.Id,
                Name = extensionFieldDefinition.Name,
                DataType = extensionFieldDefinition.DataType,
                EntityType = extensionFieldDefinition.EntityType,
                DefaultValue = extensionFieldDefinition.DefaultValue
            };

            return View("Edit", extensionFieldDefinitionViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ExtensionFieldDefinitionViewModel extensionFieldDefinitionViewModel)
        {
            ExtensionFieldDefinition extensionFieldDefinition = new ExtensionFieldDefinition();
            extensionFieldDefinition.Id = extensionFieldDefinitionViewModel.Id;
            extensionFieldDefinition.Name = extensionFieldDefinitionViewModel.Name;
            extensionFieldDefinition.EntityType = extensionFieldDefinitionViewModel.EntityType;
            extensionFieldDefinition.DataType = extensionFieldDefinitionViewModel.DataType;
            extensionFieldDefinition.DefaultValue = extensionFieldDefinitionViewModel.DefaultValue;

            ExtensionFieldDefinitionManager extensionFieldManager = new ExtensionFieldDefinitionManager(_appSettings.DefaultConnection);
            extensionFieldManager.Edit(extensionFieldDefinition);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int extensionFieldDefinitionId)
        {
            ExtensionFieldDefinitionManager extensionFieldManager = new ExtensionFieldDefinitionManager(_appSettings.DefaultConnection);
            extensionFieldManager.Delete(extensionFieldDefinitionId);

            return RedirectToAction("Index");
        }
    }
}

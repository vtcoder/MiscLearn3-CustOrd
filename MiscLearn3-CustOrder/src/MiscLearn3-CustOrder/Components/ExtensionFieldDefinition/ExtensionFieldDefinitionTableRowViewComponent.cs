using Microsoft.AspNetCore.Mvc;
using MiscLearn3_CustOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder.Components.ExtensionFieldDefinition
{
    public class ExtensionFieldDefinitionTableRowViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ExtensionFieldDefinitionViewModel extensionFieldDefinitionViewModel, bool isHeader = false)
        {
            return View(new Tuple<ExtensionFieldDefinitionViewModel, bool>(extensionFieldDefinitionViewModel, isHeader));
        }
    }
}

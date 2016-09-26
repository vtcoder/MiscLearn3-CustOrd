using MiscLearn3_CustOrder_BE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder.Models
{
    public class ExtensionFieldDefinitionViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Entity Type")]
        public EntityType EntityType { get; set; }
        [Display(Name = "Data Type")]
        public ExtensionFieldDataType DataType { get; set; }
        [Display(Name = "Default Value")]
        public string DefaultValue { get; set; }
    }
}

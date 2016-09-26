using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiscLearn3_CustOrder.Models
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
            : base()
        {
            ExtensionFields = new List<CustomerExtensionFieldViewModel>();
        }

        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public List<CustomerExtensionFieldViewModel> ExtensionFields { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models.ViewModel
{
    public class NewCategoryViewModel
    {
        public IEnumerable<Category>Category{ get; set; }
        public Product Product { get; set; }
    }
}
using ProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVC.ViewModel
{
    public class ProductView
    {
        public IEnumerable<Category> Category { get; set; }
        public Product Product { get; set; }
    }
}
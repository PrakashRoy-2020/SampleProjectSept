using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class Category
    {
      [Key]
        public int CId { get; set; }
        public string CName { get; set; }
    }
}
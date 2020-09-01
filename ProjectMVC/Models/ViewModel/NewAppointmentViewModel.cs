using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models.ViewModel
{
    public class NewAppointmentViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public Appointment Appointment  { get; set; }
    }
}
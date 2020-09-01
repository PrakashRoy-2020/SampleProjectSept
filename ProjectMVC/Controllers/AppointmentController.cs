using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC.Models;
using System.Data.Entity;
using ProjectMVC.Models.ViewModel;

namespace ProjectMVC.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        private ApplicationDbContext _context;

        public AppointmentController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var appointment = _context.Appointments.Include(c => c.Product).ToList();

            return View(appointment);

            
        }
        //public ActionResult Create()
        //{
        //    var create = _context.Products.ToList();
        //    //if (updateC == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    var vm = new NewAppointmentViewModel
        //    {
        //        // Appointment = updateCust,
        //        Product = create
        //    };
        //    return View(vm);

        //} 
        [HttpPost]
        public ActionResult Save(Appointment appointment)
        {
            if (appointment.Id == 0)
                _context.Appointments.Add(appointment);
            else
            {
                var appInDb = _context.Appointments.Single(c => c.Id == appointment.Id);
                //TryUpdateModel(appInDb,"",new string[] { });
                appInDb.PersonName = appointment.PersonName;
                appInDb.PhoneNumber = appointment.PhoneNumber;
                appInDb.Email = appointment.Email;
                appInDb.Date = appointment.Date;
                appInDb.Product = appointment.Product;
            }
            
            //_context.Appointments.Add(appointment);
            _context.SaveChanges();
            return RedirectToAction("Index", "Appointments");
        }

        public ActionResult New()
        {
            var product1 = _context.Products.ToList();
            var viewModel = new NewAppointmentViewModel
            {
                Product=product1
            };
            return View(viewModel);
        }

        //[HttpPost]
        //public ActionResult Save(Appointment appointment)
        //{
        //    if (appointment.AId == 0)
        //        _context.Appointments.Add(appointment);
        //    else
        //    {
        //        var AppointmentInDb = _context.Appointments.Single(c => c.Id == appointment.AId);
        //        AppointmentInDb.PersonName = appointment.PersonName;
        //        AppointmentInDb.PhoneNumber = appointment.PhoneNumber;
        //        AppointmentInDb.Email = appointment.Email;
        //        AppointmentInDb.Date = appointment.Date;
        //        AppointmentInDb.Product = appointment.Product;
                    
                
        //    }
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Appointment");//Back to customer controller page
        //}

        [HttpPost]
        //public ActionResult Edit(int id)
        //{
        //    //var updateCust = _context.Appointments.SingleOrDefault(c => c.Id == id);
        //    var edit = _context.Products.ToList();
        //    //if (updateC == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    var vm = new NewAppointmentViewModel
        //    {
        //        // Appointment = updateCust,
        //        Product = edit
        //    };
        //    return View("New",vm);
        //}
        public ActionResult Edit(int id)
        {
            var obj = _context.Appointments.SingleOrDefault(c => c.AId == id);
            if (obj == null)
                return HttpNotFound();

            var vm = new NewAppointmentViewModel
            {
                Appointment = obj,
                Product = _context.Products.ToList()
            };

            return View("New",vm);
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
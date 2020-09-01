using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Category
        [HttpGet]
        public ActionResult Index()

        {
            var category = _context.Categories.ToList();



            return View(category);
        }
        //[HttpPost]
        //public ActionResult Create(Category category)//Model Binding
        //{
        //    if (category.CId == 0)
        //        _context.Categories.Add(category);
        //    else
        //    {
        //        var categoryInDb = _context.Categories.Single(c => c.CId == category.CId);

        //        categoryInDb.CName = category.CName;

        //    }
        //    _context.SaveChanges();

        //    return RedirectToAction("Index", "Category");
        //}
        public ActionResult Create()
        {
            return View();
        }

        //  
        // POST: /CRUD/Create  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }




    }
}
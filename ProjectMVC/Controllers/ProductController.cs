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
    public class ProductController : Controller
    {
        // GET: Product
        private ApplicationDbContext _context;

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            {
                //var categories = _context.Categories.ToList();

                //var viewModel = new NewProductCategory
                //{
                //    Categories = categories
                //};
                var product = _context.Products.Include(c => c.Category).ToList();

                return View(product);
                //return View(viewModel);
            }

        }
        public ActionResult Details(int id)
        {
            var singleproduct = _context.Products.Include(c => c.Category).SingleOrDefault(c=>c.Id==id);
            
            return View(singleproduct);
            
        }

        //public ActionResult Create(
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Products.Add(product);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(product);
        //}
        [HttpGet]
        public ActionResult New()
        {
            var category1 = _context.Categories.ToList();
            var viewModel = new NewCategoryViewModel
            {
                Category = category1
            };
            return View(viewModel);
        }
        public ActionResult Save(Product products)
        {
            if (products.Id == 0)
                _context.Products.Add(products);
            else
            {
                var ProductInDb = _context.Products.Single(c => c.Id == products.Id);
                ProductInDb.Price= products.Price;
                ProductInDb.ShadeColour = products.ShadeColour;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");//Back to customer controller page
        }
    }


}
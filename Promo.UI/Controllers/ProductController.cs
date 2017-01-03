using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Promo.DataLayer;
using Promo.Model.Models;
using Promo.BusinessLogic.Products;
using Promo.Model.ViewModels;
using System.IO;

namespace Promo.UI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private ProductManager _productManager = new ProductManager();

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            return View(_productManager.GetAllProducts());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productManager.GetProduct(productId);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View(_productManager.GetEmptyProduct());
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            var product = productViewModel.Product;
            if (ModelState.IsValid)
            {
                byte[] image = null;

                if (productViewModel.File != null && productViewModel.File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(productViewModel.File.FileName);
                    string path;
                    if (fileName != null)
                    {
                        path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                        productViewModel.File.SaveAs(path);
                        image = System.IO.File.ReadAllBytes(path);
                        System.IO.File.Delete(path);

                    }

                }
                product.Image = image;
                _productManager.AddProduct(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductViewModel product = _productManager.GetProductToEdit(productId);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            var product = productViewModel.Product;
            if (ModelState.IsValid)
            {
                byte[] image = null;

                if (productViewModel.File != null && productViewModel.File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(productViewModel.File.FileName);
                    string path;
                    if (fileName != null)
                    {
                        path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                        productViewModel.File.SaveAs(path);
                        image = System.IO.File.ReadAllBytes(path);
                        System.IO.File.Delete(path);

                    }

                }
                product.Image = image;
                _productManager.EditProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}

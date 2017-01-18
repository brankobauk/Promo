using System.Net;
using System.Web.Mvc;
using Promo.Model.Models;
using Promo.BusinessLogic.Brands;
using System.Web;
using System.IO;
using System.Drawing;

namespace Promo.UI.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        private BrandManager _brandManager = new BrandManager();

        // GET: Brands
        public ActionResult Index()
        {
            return View(_brandManager.GetAllBrands());
        }

        // GET: Brands/Details/5
        public ActionResult Details(int? brandId)
        {
            if (brandId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = _brandManager.GetBrand(brandId);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Brands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                byte[] image = null;
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string path;
                    if (fileName != null)
                    {
                        path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                        file.SaveAs(path);
                        image = System.IO.File.ReadAllBytes(path);
                        System.IO.File.Delete(path);

                    }

                }
                brand.Image = image;
                _brandManager.AddBrand(brand);
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        // GET: Brands/Edit/5
        public ActionResult Edit(int? brandId)
        {
            if (brandId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = _brandManager.GetBrand(brandId);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                

                byte[] image = null;
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string path;
                    if (fileName != null)
                    {
                        path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                        file.SaveAs(path);
                        image = System.IO.File.ReadAllBytes(path);
                        System.IO.File.Delete(path);
                        
                    }
                    
                }
                brand.Image = image;
                _brandManager.EditBrand(brand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }
    }
}

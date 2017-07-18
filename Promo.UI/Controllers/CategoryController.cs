using System;
using System.Net;
using System.Web.Mvc;
using Promo.Model.Models;
using Promo.BusinessLogic.Errors;
using Promo.Helpers.Mappers;
using Promo.BusinessLogic.Categories;

namespace Promo.UI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private CategoryManager _categoryManager = new CategoryManager();
        private readonly ErrorManager _errorManager = new ErrorManager();
        private readonly ErrorMapper _errorMapper = new ErrorMapper();

        // GET: Category
        public ActionResult Index()
        {
            try
            {
                return View(_categoryManager.GetAllCategories());
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorManager.Log(_errorMapper.MapError(ex, url));
                return RedirectToAction("Index", "Error");
            }

        }

        // GET: Category/Details/5
        public ActionResult Details(int? categoryId)
        {
            try
            {
                if (categoryId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Category category = _categoryManager.GetCategoryToEdit(categoryId);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorManager.Log(_errorMapper.MapError(ex, url));
                return RedirectToAction("Index", "Error");
            }

        }

        // GET: Category/Create
        public ActionResult Create()
        {
            try
            {
                var categoryViewModel = _categoryManager.GetEmptyCategory();
                return View(categoryViewModel);
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorManager.Log(_errorMapper.MapError(ex, url));
                return RedirectToAction("Index", "Error");
            }

        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Name, ParentId")] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryManager.AddCategory(category);
                    return RedirectToAction("Index");
                }

                return View(category);
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorManager.Log(_errorMapper.MapError(ex, url));
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? categoryId)
        {
            try
            {
                if (categoryId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var categoryViewModel = _categoryManager.GetCategory(categoryId);
                if (categoryViewModel.Category == null)
                {
                    return HttpNotFound();
                }
                
                return View(categoryViewModel);
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorManager.Log(_errorMapper.MapError(ex, url));
                return RedirectToAction("Index", "Error");
            }

        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,ParentId,Name")] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryManager.EditCategory(category);
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorManager.Log(_errorMapper.MapError(ex, url));
                return RedirectToAction("Index", "Error");
            }

        }
        [OverrideAuthorization]
        public ActionResult GetAllActiveCategories()
        {
            try
            {

                return PartialView(_categoryManager.GetAllCategories());
            }
            catch (Exception ex)
            {
                var url = "";
                if (Request.Url != null)
                {
                    url = Request.Url.AbsoluteUri;
                }
                _errorManager.Log(_errorMapper.MapError(ex, url));
                return RedirectToAction("Index", "Error");
            }
        }

    }
}

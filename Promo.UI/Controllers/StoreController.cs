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
using Promo.BusinessLogic.Stores;
using Promo.Model.ViewModels;
using Promo.BusinessLogic.Errors;
using Promo.Helpers.Mappers;

namespace Promo.UI.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreManager _storeManager = new StoreManager();
        private readonly ErrorManager _errorManager = new ErrorManager();
        private readonly ErrorMapper _errorMapper = new ErrorMapper();
        // GET: Store
        public ActionResult Index()
        {
            try
            {
                return View(_storeManager.GetAllStores());
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

        // GET: Store/Details/5
        public ActionResult Details(int? storeId)
        {
            try
            {
                if (storeId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Store store = _storeManager.GetStore(storeId);
                if (store == null)
                {
                    return HttpNotFound();
                }
                return View(store);
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

        // GET: Store/Create
        public ActionResult Create()
        {
            try
            {
                return View(_storeManager.GetEmptyStore());
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

        // POST: Store/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreId,Name,Location,CompanyId")] Store store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _storeManager.AddStore(store);
                    return RedirectToAction("Index");
                }

                return View(store);
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

        // GET: Store/Edit/5
        public ActionResult Edit(int? storeId)
        {
            try
            {
                if (storeId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                StoreViewModel storeViewModel = _storeManager.GetPromotionToEdit(storeId);
                if (storeViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(storeViewModel);
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

        // POST: Store/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoreId,Name,Location,CompanyId")] Store store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _storeManager.EditStore(store);
                    return RedirectToAction("Index");
                }
                return View(store);
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

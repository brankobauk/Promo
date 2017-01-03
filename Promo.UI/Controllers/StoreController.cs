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

namespace Promo.UI.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreManager _storeManager = new StoreManager();
        // GET: Store
        public ActionResult Index()
        {
            return View(_storeManager.GetAllStores());
        }

        // GET: Store/Details/5
        public ActionResult Details(int? storeId)
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

        // GET: Store/Create
        public ActionResult Create()
        {
            return View(_storeManager.GetEmptyStore());
        }

        // POST: Store/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreId,Name,Location,CompanyId")] Store store)
        {
            if (ModelState.IsValid)
            {
                _storeManager.AddStore(store);
                return RedirectToAction("Index");
            }

            return View(store);
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int? storeId)
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

        // POST: Store/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoreId,Name,Location,CompanyId")] Store store)
        {
            if (ModelState.IsValid)
            {
                _storeManager.EditStore(store);
                return RedirectToAction("Index");
            }
            return View(store);
        }
    }
}

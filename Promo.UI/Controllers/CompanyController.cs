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
using Promo.BusinessLogic.Companies;

namespace Promo.UI.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private CompanyManager _companyManager = new CompanyManager();

        // GET: Company
        public ActionResult Index()
        {
            return View(_companyManager.GetAllCompanies());
        }

        // GET: Company/Details/5
        public ActionResult Details(int? companyId)
        {
            if (companyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _companyManager.GetCompany(companyId);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyId,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                _companyManager.AddCompany(company);
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? companyId)
        {
            if (companyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _companyManager.GetCompany(companyId);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyId,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                _companyManager.EditCompany(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }

    }
}

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
using Promo.BusinessLogic.Errors;
using Promo.Helpers.Mappers;

namespace Promo.UI.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private CompanyManager _companyManager = new CompanyManager();
        private readonly ErrorManager _errorManager = new ErrorManager();
        private readonly ErrorMapper _errorMapper = new ErrorMapper();

        // GET: Company
        public ActionResult Index()
        {
            try
            {
                return View(_companyManager.GetAllCompanies());
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

        // GET: Company/Details/5
        public ActionResult Details(int? companyId)
        {
            try
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

        // GET: Company/Create
        public ActionResult Create()
        {
            try
            {
                return View();
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

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyId,Name")] Company company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _companyManager.AddCompany(company);
                    return RedirectToAction("Index");
                }

                return View(company);
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

        // GET: Company/Edit/5
        public ActionResult Edit(int? companyId)
        {
            try
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

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyId,Name")] Company company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _companyManager.EditCompany(company);
                    return RedirectToAction("Index");
                }
                return View(company);
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

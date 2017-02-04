using System.Net;
using System.Web.Mvc;
using Promo.Model.Models;
using Promo.BusinessLogic.Countries;
using Promo.BusinessLogic.Errors;
using Promo.Helpers.Mappers;
using System;

namespace Promo.UI.Controllers
{
    [Authorize]
    public class CountryController : Controller
    {
        private CountryManager _countryManager = new CountryManager();
        private readonly ErrorManager _errorManager = new ErrorManager();
        private readonly ErrorMapper _errorMapper = new ErrorMapper();
        // GET: Country
        public ActionResult Index()
        {
            try
            {
                return View(_countryManager.GetCountries());
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

        // GET: Country/Details/5
        public ActionResult Details(int? countryId)
        {
            try
            {
                if (countryId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Country country = _countryManager.GetCountry(countryId);
                if (country == null)
                {
                    return HttpNotFound();
                }
                return View(country);
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

        // GET: Country/Create
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

        // POST: Country/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryId,Name")] Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _countryManager.AddCountry(country);
                    return RedirectToAction("Index");
                }

                return View(country);
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

        // GET: Country/Edit/5
        public ActionResult Edit(int? countryId)
        {
            try
            {
                if (countryId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Country country = _countryManager.GetCountry(countryId);
                if (country == null)
                {
                    return HttpNotFound();
                }
                return View(country);
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

        // POST: Country/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,Name")] Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _countryManager.EditCountry(country);
                    return RedirectToAction("Index");
                }
                return View(country);
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

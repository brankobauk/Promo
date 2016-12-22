using System.Net;
using System.Web.Mvc;
using Promo.Model.Models;
using Promo.BusinessLogic.Countries;

namespace Promo.UI.Controllers
{
    [Authorize]
    public class CountryController : Controller
    {
        private CountryManager _countryManager = new CountryManager();

        // GET: Country
        public ActionResult Index()
        {
            return View(_countryManager.GetCountries());
        }

        // GET: Country/Details/5
        public ActionResult Details(int? countryId)
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

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryId,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                _countryManager.AddCountry(country);
                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int? countryId)
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

        // POST: Country/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                _countryManager.EditCountry(country);
                return RedirectToAction("Index");
            }
            return View(country);
        }
    }
}

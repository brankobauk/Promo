using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Promo.Model.Models;
using Promo.BusinessLogic.Promotions;

namespace Promo.UI.Controllers
{
    [Authorize]
    public class PromotionController : Controller
    {
        private PromotionManager _promotionManager = new PromotionManager();

        // GET: Promotion
        public ActionResult Index()
        {
            return View(_promotionManager.GetAllPromotions());
        }

        // GET: Promotion/Details/5
        public ActionResult Details(int? promotionId)
        {
            if (promotionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promotion promotion = _promotionManager.GetPromotion(promotionId);
            if (promotion == null)
            {
                return HttpNotFound();
            }
            return View(promotion);
        }

        // GET: Promotion/Create
        public ActionResult Create()
        {
            return View(_promotionManager.GetEmptyPromotion());
        }

        // POST: Promotion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PromotionId,Name,CompanyId,CountryId,StartDate,EndDate")] Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                _promotionManager.AddPromotion(promotion);
                return RedirectToAction("Index");
            }

            return View(promotion);
        }

        // GET: Promotion/Edit/5
        public ActionResult Edit(int? promotionId)
        {
            if (promotionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var promotion = _promotionManager.GetPromotionToEdit(promotionId);
            if (promotion == null)
            {
                return HttpNotFound();
            }
            return View(promotion);
        }

        // POST: Promotion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PromotionId,Name,CompanyId,CountryId,StartDate,EndDate")] Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                _promotionManager.EditPromotion(promotion);
                return RedirectToAction("Index");
            }
            return View(promotion);
        }
    }
}

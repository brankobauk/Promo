using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Promo.Model.Models;
using Promo.BusinessLogic.Promotions;
using System.Web;
using System.IO;
using Promo.Model.ViewModels;

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
        public ActionResult Create(PromotionViewModel promotionViewModel, HttpPostedFileBase file)
        {
            var promotion = promotionViewModel.Promotion;
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
                promotion.Image = image;
                _promotionManager.AddPromotion(promotion);
                if (promotion.PromotionId != 0)
                {
                    _promotionManager.AddPromotionBrands(promotion.PromotionId, promotionViewModel.BrandIds);
                    _promotionManager.AddPromotionStores(promotion.PromotionId, promotionViewModel.StoreIds);
                }
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
        public ActionResult Edit( PromotionViewModel promotionViewModel)
        {
            var promotion = promotionViewModel.Promotion;
            if (ModelState.IsValid)
            {
                byte[] image = null;
                
                if (promotionViewModel.File != null && promotionViewModel.File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(promotionViewModel.File.FileName);
                    string path;
                    if (fileName != null)
                    {
                        path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                        promotionViewModel.File.SaveAs(path);
                        image = System.IO.File.ReadAllBytes(path);
                        System.IO.File.Delete(path);

                    }

                }
                promotion.Image = image;
                _promotionManager.EditPromotion(promotion);

                _promotionManager.DeletePromotionBrands(promotion.PromotionId);
                _promotionManager.AddPromotionBrands(promotion.PromotionId, promotionViewModel.BrandIds);

                _promotionManager.DeletePromotionStores(promotion.PromotionId);
                _promotionManager.AddPromotionStores(promotion.PromotionId, promotionViewModel.StoreIds);

                return RedirectToAction("Index");
            }
            return View(promotion);
        }
    }
}

using Promo.BusinessLogic.Brands;
using Promo.BusinessLogic.Promotions;
using Promo.BusinessLogic.Stores;
using Promo.Model.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Promo.UI.Controllers
{
    public class ApiController : Controller
    {
        private readonly BrandManager _brandManager = new BrandManager();
        private readonly PromotionManager _promotionManager = new PromotionManager();
        private readonly StoreManager _storeManager = new StoreManager();
        public ActionResult GetPromotionBrands(int promotionId)
        {
            var items = _promotionManager.GetPromotionBrands(promotionId);
            return this.Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPublishedBrands()
        {
            var brands = _brandManager.GetAllPublishedBrandsForJson();
            return Json(brands, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPromotionStores(int promotionId)
        {
            var items = _promotionManager.GetPromotionStores(promotionId);
            return this.Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStoresByCompanyForJson(int companyId)
        {
            var stores = _storeManager.GetStoresByCompanyForJson(companyId);
            return Json(stores, JsonRequestBehavior.AllowGet);
        }
    }
}
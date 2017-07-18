using Promo.BusinessLogic.Errors;
using Promo.BusinessLogic.Promotions;
using Promo.Helpers.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Promo.UI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ErrorManager _errorManager = new ErrorManager();
        private readonly ErrorMapper _errorMapper = new ErrorMapper();
        private readonly PromotionManager _promotionMAnager = new PromotionManager();
        public ActionResult Index(int? brandId, int? storeId, int? categoryId)
        {
            try
            {
                var activePromotions = _promotionMAnager.GetAllActivePromotions(brandId, storeId, categoryId);
                return View(activePromotions);
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
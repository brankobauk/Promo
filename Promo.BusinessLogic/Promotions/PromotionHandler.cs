using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promo.DataLayer;
using Promo.DataLayer.Repositories;
using Promo.Model.Models;

namespace Promo.BusinessLogic.Promotions
{
    
    public class PromotionHandler
    {
        private PromotionRepository _promotionRepository = new PromotionRepository();
        public List<Promotion> GetAllPromotions()
        {
            return _promotionRepository.GetAllPromotions();
        }

        public Promotion GetPromotion(int? PromotionId)
        {
            return _promotionRepository.GetPromotion(PromotionId);
        }

        public void AddPromotion(Promotion Promotion)
        {
            _promotionRepository.AddPromotion(Promotion);
        }

        public void EditPromotion(Promotion Promotion)
        {
            _promotionRepository.EditPromotion(Promotion);
        }
    }
}

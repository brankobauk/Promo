using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promo.DataLayer;
using Promo.DataLayer.Repositories;
using Promo.Model.Models;
using Promo.Model.HelperModels;

namespace Promo.BusinessLogic.Promotions
{
    
    public class PromotionHandler
    {
        private PromotionRepository _promotionRepository = new PromotionRepository();
        public List<Promotion> GetAllPromotions()
        {
            return _promotionRepository.GetAllPromotions();
        }

        public Promotion GetPromotion(int? promotionId)
        {
            return _promotionRepository.GetPromotion(promotionId);
        }

        public void AddPromotion(Promotion promotion)
        {
            _promotionRepository.AddPromotion(promotion);
        }

        public void EditPromotion(Promotion promotion)
        {
            _promotionRepository.EditPromotion(promotion);
        }

        public void AddPromotionBrand(PromotionBrand promotionBrand)
        {
            _promotionRepository.AddPromotionBrand(promotionBrand);
        }

        public int[] GetPromotionBrands(int? promotionId)
        {
             return _promotionRepository.GetPromotionBrands(promotionId).Select(p=>p.BrandId).ToArray();
        }

        public void DeletePromotionBrands(int promotionId)
        {
            _promotionRepository.DeletePromotionBrands(promotionId);
        }

        public int[] GetPromotionStores(int? promotionId)
        {
            return _promotionRepository.GetPromotionStores(promotionId).Select(p => p.StoreId).ToArray();
        }

        public void AddPromotionStore(PromotionStore promotionStore)
        {
            _promotionRepository.AddPromotionStore(promotionStore);
        }

        public void DeletePromotionStores(int promotionId)
        {
            _promotionRepository.DeletePromotionStores(promotionId);
        }

        public List<Promotion> GetAllActivePromotions(int? brandId, int? storeId, int? categoryId)
        {
            return _promotionRepository.GetAllActivePromotions(brandId, storeId, categoryId);
        }
    }
}

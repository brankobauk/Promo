using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.DataLayer.Repositories
{
    public class PromotionRepository
    {
        public List<Promotion> GetAllPromotions()
        { 
            using(var _db = new ApplicationDbContext())
            {
                    return _db.Promotion.ToList();
            }
        }

        public Promotion GetPromotion(int? promotionId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Promotion.Find(promotionId);
            }
        }

        public void AddPromotion(Promotion promotion)
        {
            using (var _db = new ApplicationDbContext())
            {
                 _db.Promotion.Add(promotion);
                _db.SaveChanges();
            }
        }

        public void EditPromotion(Promotion promotion)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Entry(promotion).State = EntityState.Modified;
                if (promotion.Image == null)
                    _db.Entry(promotion).Property(m => m.Image).IsModified = false;
                _db.SaveChanges();
            }
        }

        public void AddPromotionBrand(PromotionBrand promotionBrand)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.PromotionBrand.Add(promotionBrand);
                _db.SaveChanges();
            }
        }

        public List<PromotionStore> GetPromotionStores(int? promotionId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.PromotionStore.Where(p => p.PromotionId == promotionId).ToList();
            }
        }

        public List<PromotionBrand> GetPromotionBrands(int? promotionId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.PromotionBrand.Where(p=>p.PromotionId == promotionId).ToList();
            }
        }

        public List<Promotion> GetAllActivePromotions(int? brandId, int? storeId, int? categoryId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Promotion.Where(p => p.StartDate < DateTime.Now && p.EndDate > DateTime.Now ).ToList();
            }
        }

        public void DeletePromotionStores(int promotionId)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.PromotionStore.RemoveRange(_db.PromotionStore.Where(p => p.PromotionId == promotionId));
                _db.SaveChanges();
            }
        }

        public void AddPromotionStore(PromotionStore promotionStore)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.PromotionStore.Add(promotionStore);
                _db.SaveChanges();
            }
        }

        public void DeletePromotionBrands(int promotionId)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.PromotionBrand.RemoveRange(_db.PromotionBrand.Where(p=>p.PromotionId == promotionId));
                _db.SaveChanges();
            }
        }
    }
}

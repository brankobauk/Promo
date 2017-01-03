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
    }
}

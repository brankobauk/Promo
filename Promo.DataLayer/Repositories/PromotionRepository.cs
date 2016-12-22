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

        public Promotion GetPromotion(int? PromotionId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Promotion.Find(PromotionId);
            }
        }

        public void AddPromotion(Promotion Promotion)
        {
            using (var _db = new ApplicationDbContext())
            {
                 _db.Promotion.Add(Promotion);
                _db.SaveChanges();
            }
        }

        public void EditPromotion(Promotion Promotion)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Entry(Promotion).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}

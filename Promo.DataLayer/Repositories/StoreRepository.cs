using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.DataLayer.Repositories
{
    public class StoreRepository
    {
        public List<Store> GetAllStores()
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Store.ToList();
            }
        }

        public Store GetStore(int? storeId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Store.Find(storeId);
            }
        }

        public void AddStore(Store store)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Store.Add(store);
                _db.SaveChanges();
            }
        }

        public void EditStore(Store store)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Entry(store).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}

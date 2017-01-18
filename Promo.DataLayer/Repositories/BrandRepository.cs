using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promo.Model.HelperModels;

namespace Promo.DataLayer.Repositories
{
    public class BrandRepository
    {
        public List<Brand> GetAllBrands()
        { 
            using(var _db = new ApplicationDbContext())
            {
                    return _db.Brand.ToList();
            }
        }

        public Brand GetBrand(int? brandId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Brand.Find(brandId);
            }
        }

        public void AddBrand(Brand brand)
        {
            using (var _db = new ApplicationDbContext())
            {
                 _db.Brand.Add(brand);
                _db.SaveChanges();
            }
        }

        public List<Brand> GetBrandsByText(string text)
        {
            
            using (var _db = new ApplicationDbContext())
            {

                return _db.Brand.Where(p => p.Name.ToLower().Contains(text.ToLower())).ToList();
            }
        }
        public void EditBrand(Brand brand)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Entry(brand).State = EntityState.Modified;
                if (brand.Image == null)
                    _db.Entry(brand).Property(m => m.Image).IsModified = false;
                _db.SaveChanges();
            }
        }
    }
}

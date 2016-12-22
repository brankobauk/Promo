using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.DataLayer.Repositories
{
    public class ProductRepository
    {
        public List<Product> GetAllProducts()
        { 
            using(var _db = new ApplicationDbContext())
            {
                    return _db.Product.ToList();
            }
        }

        public Product GetProduct(int? ProductId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Product.Find(ProductId);
            }
        }

        public void AddProduct(Product Product)
        {
            using (var _db = new ApplicationDbContext())
            {
                 _db.Product.Add(Product);
                _db.SaveChanges();
            }
        }

        public void EditProduct(Product Product)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Entry(Product).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}

﻿using Promo.Model.Models;
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

        public Product GetProduct(int? productId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Product.Find(productId);
            }
        }

        public void AddProduct(Product product)
        {
            using (var _db = new ApplicationDbContext())
            {
                 _db.Product.Add(product);
                _db.SaveChanges();
            }
        }

        public void EditProduct(Product product)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Entry(product).State = EntityState.Modified;
                if (product.Image == null)
                    _db.Entry(product).Property(m => m.Image).IsModified = false;
                _db.SaveChanges();
            }
        }
    }
}

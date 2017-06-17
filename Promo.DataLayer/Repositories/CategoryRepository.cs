using Promo.Model.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Promo.DataLayer.Repositories
{
    public class CategoryRepository
    {
        public List<Category> GetAllCategories()
        { 
            using(var _db = new ApplicationDbContext())
            {
                    return _db.Category.ToList();
            }
        }

        public Category GetCategory(int? CategoryId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Category.Find(CategoryId);
            }
        }

        public void AddCategory(Category Category)
        {
            using (var _db = new ApplicationDbContext())
            {
                 _db.Category.Add(Category);
                _db.SaveChanges();
            }
        }

        public void EditCategory(Category Category)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Entry(Category).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}

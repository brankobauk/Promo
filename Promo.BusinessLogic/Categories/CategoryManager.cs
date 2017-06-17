using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.BusinessLogic.Categories
{
    public class CategoryManager
    {
        private CategoryHandler _categoryHandler = new CategoryHandler();
        public List<Category> GetAllCategories()
        {
            return _categoryHandler.GetAllCategories();
        }

        public Category GetCategory(int? categoryId)
        {
            return _categoryHandler.GetCategory(categoryId);
        }

        public void AddCategory(Category category)
        {
            _categoryHandler.AddCategory(category);
        }

        public void EditCategory(Category category)
        {
            _categoryHandler.EditCategory(category);
        }
    }
}

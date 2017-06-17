using Promo.DataLayer.Repositories;
using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.BusinessLogic.Categories
{
    public class CategoryHandler
    {
        private CategoryRepository _categoryRepository = new CategoryRepository();
        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategory(int? categoryId)
        {
            return _categoryRepository.GetCategory(categoryId);
        }

        public void AddCategory(Category category)
        {
            _categoryRepository.AddCategory(category);
        }

        public void EditCategory(Category category)
        {
            _categoryRepository.EditCategory(category);
        }
    }
}

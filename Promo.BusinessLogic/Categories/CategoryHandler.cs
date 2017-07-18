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

        public List<Category> GetAllSortedCategories()
        {
            var sortedCategories = new List<Category>();
            var categories =  _categoryRepository.GetAllCategories().ToList();
            var rootCtegories = categories.Where(p => p.ParentId == 0).OrderBy(p=>p.SortOrder);

            foreach (var rootCat in rootCtegories)
            {
                rootCat.Level = 1;
                sortedCategories.AddRange(categories.Where(p => p.CategoryId == rootCat.CategoryId));
                var secondCategories = categories.Where(p => p.ParentId == rootCat.CategoryId).OrderBy(p => p.SortOrder).ToList();
                foreach (var secCat in secondCategories)
                {
                    secCat.Level = 2;
                    sortedCategories.AddRange(categories.Where(p => p.CategoryId == secCat.CategoryId));
                    var thirdCategories = categories.Where(p => p.ParentId == secCat.CategoryId).OrderBy(p => p.SortOrder).ToList();
                    foreach (var thirdCat in thirdCategories)
                    {
                        thirdCat.Level = 3;
                        sortedCategories.AddRange(categories.Where(p => p.CategoryId == thirdCat.CategoryId));
                    }
                }
            }
            return sortedCategories;
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

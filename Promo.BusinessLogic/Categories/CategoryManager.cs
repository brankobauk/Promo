using Promo.Helpers.Dropdowns;
using Promo.Model.Models;
using Promo.Model.ViewModels;
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
        private DropDownHelpers _dropDownHelper = new DropDownHelpers();
        public List<Category> GetAllCategories()
        {
            return _categoryHandler.GetAllCategories();
        }

        public Category GetCategoryToEdit(int? categoryId)
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

        public CategoryViewModel GetEmptyCategory()
        {
            return new CategoryViewModel()
            {
                Categories = _dropDownHelper.GetCategoryListForDropDown(_categoryHandler.GetAllSortedCategories())
            };
        }

        public CategoryViewModel GetCategory(int? categoryId)
        {
            return new CategoryViewModel()
            {
                Category = _categoryHandler.GetCategory(categoryId),
                Categories = _dropDownHelper.GetCategoryListForDropDown(_categoryHandler.GetAllSortedCategories())
                
            };
        }
    }
}

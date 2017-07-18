using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Globalization;
using Promo.Model.HelperModels;

namespace Promo.Helpers.Dropdowns
{
    public class DropDownHelpers
    {
        public IEnumerable<SelectListItem> GetBrandListForDropDown(List<Brand> brands)
        {
            return brands.Select(brand => new SelectListItem { Value = brand.BrandId.ToString(CultureInfo.InvariantCulture), Text = brand.Name.ToString(CultureInfo.InvariantCulture) }).ToList();
        }

        public IEnumerable<SelectListItem> GetCountryListForDropDown(List<Country> countries)
        {
            return countries.Select(country => new SelectListItem { Value = country.CountryId.ToString(CultureInfo.InvariantCulture), Text = country.Name.ToString(CultureInfo.InvariantCulture) }).ToList();
        }

        public IEnumerable<SelectListItem> GetCompanyListForDropDown(List<Company> companies)
        {
            return companies.Select(company => new SelectListItem { Value = company.CompanyId.ToString(CultureInfo.InvariantCulture), Text = company.Name.ToString(CultureInfo.InvariantCulture) }).ToList();
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown(List<Category> categories)
        {
            return   categories.Select(category => new SelectListItem { Value = category.CategoryId.ToString(CultureInfo.InvariantCulture), Text = GetCategoryText(category) }).ToList();
        }

        private string GetCategoryText(Category category)
        {
            var text = "";
            for (var i = 1; i < category.Level; i++)
            {
                text = text + "\xA0\xA0";
            }
        return text + category.Name;
        }
    }
}

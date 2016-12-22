using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Globalization;

namespace Promo.Helpers
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
    }
}

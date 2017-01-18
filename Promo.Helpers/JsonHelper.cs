using Promo.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Promo.Model.HelperModels;
using System;

namespace Promo.Helpers
{
    public class JsonHelper
    {
        public IEnumerable<SelectItem> GetBrandListForJson(List<Brand> brands)
        {
            return brands.Select(brand => new SelectItem { id = brand.BrandId, text = brand.Name.ToString(CultureInfo.InvariantCulture) }).ToList();
        }

        public IEnumerable<SelectItem> GetStoresByCompanyForJson(List<Store> stores)
        {
            return stores.Select(store => new SelectItem { id = store.StoreId, text = store.Name.ToString(CultureInfo.InvariantCulture) }).ToList();
        }
    }
}

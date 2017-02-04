using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promo.Model.HelperModels;
using Promo.Helpers;
using Promo.Helpers.Json;

namespace Promo.BusinessLogic.Brands
{
    public class BrandManager
    {
        private BrandHandler _brandHandler = new BrandHandler();
        private JsonHelpers _jsonHelper = new JsonHelpers();
        public List<Brand> GetAllBrands()
        {
            return _brandHandler.GetAllBrands();
        }

        public IEnumerable<SelectItem> GetAllPublishedBrandsForJson()
        {
            return _jsonHelper.GetBrandListForJson(_brandHandler.GetAllBrands().Where(p=>p.Published == true).ToList());
        }

        public IEnumerable<SelectItem> GetBrandsByText(string text)
        {
            var brands = new List<SelectItem>();
            foreach (var item in _brandHandler.GetBrandsByText(text))
            {
                SelectItem brand = new SelectItem()
                {
                    id = item.BrandId,
                    text = item.Name
                };
                brands.Add(brand);
            }
            return brands;
        }

        public IEnumerable<SelectItem> GetBrandsByIds(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids)) return null;

            var brands = new List<SelectItem>();
            string[] idList = ids.Split(new char[] { ',' });
            foreach (var idStr in idList)
            {
                int idInt;
                if (int.TryParse(idStr, out idInt))
                {
                    var item = _brandHandler.GetBrand(Convert.ToInt32(idStr));
                    SelectItem brand = new SelectItem()
                    {
                        id = item.BrandId,
                        text = item.Name
                    };
                    brands.Add(brand);
                }
            }

            return brands;
        }

        public Brand GetBrand(int? brandId)
        {
            return _brandHandler.GetBrand(brandId);
        }

        public void AddBrand(Brand brand)
        {
            _brandHandler.AddBrand(brand);
        }

        public void EditBrand(Brand brand)
        {
            _brandHandler.EditBrand(brand);
        }
    }
}

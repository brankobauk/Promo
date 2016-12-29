using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.BusinessLogic.Brands
{
    public class BrandManager
    {
        private BrandHandler _brandHandler = new BrandHandler();
        public List<Brand> GetAllBrands()
        {
            return _brandHandler.GetAllBrands();
        }

        public List<Brand> GetAllPublishedBrands()
        {
            return _brandHandler.GetAllBrands().Where(p=>p.Published == true).ToList();
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

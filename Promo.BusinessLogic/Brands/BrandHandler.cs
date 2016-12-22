using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promo.DataLayer;
using Promo.DataLayer.Repositories;
using Promo.Model.Models;

namespace Promo.BusinessLogic.Brands
{
    
    public class BrandHandler
    {
        private BrandRepository _brandRepository = new BrandRepository();
        public List<Brand> GetAllBrands()
        {
            return _brandRepository.GetAllBrands();
        }

        public Brand GetBrand(int? brandId)
        {
            return _brandRepository.GetBrand(brandId);
        }

        public void AddBrand(Brand brand)
        {
            _brandRepository.AddBrand(brand);
        }

        public void EditBrand(Brand brand)
        {
            _brandRepository.EditBrand(brand);
        }
    }
}

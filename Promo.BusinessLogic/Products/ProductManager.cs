using Promo.BusinessLogic.Brands;
using Promo.BusinessLogic.Countries;
using Promo.Helpers;
using Promo.Model.Models;
using Promo.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.BusinessLogic.Products
{
    public class ProductManager
    {
        private ProductHandler _productHandler = new ProductHandler();
        private BrandHandler _brandHandler = new BrandHandler();
        private CountryHandler _countryHandler = new CountryHandler();
        private DropDownHelpers _dropDownHelper = new DropDownHelpers();
        public List<Product> GetAllProducts()
        {
            return _productHandler.GetAllProducts();
        }

        public Product GetProduct(int? ProductId)
        {
            return _productHandler.GetProduct(ProductId);
        }

        public ProductViewModel GetEmptyProduct()
        {
            return new ProductViewModel()
            {
                Brands = _dropDownHelper.GetBrandListForDropDown(_brandHandler.GetAllBrands()),
                Countries = _dropDownHelper.GetCountryListForDropDown(_countryHandler.GetCountries())
            };
        }

        public void AddProduct(Product Product)
        {
            _productHandler.AddProduct(Product);
        }

        public void EditProduct(Product Product)
        {
            _productHandler.EditProduct(Product);
        }

        public ProductViewModel GetProductToEdit(int? productId)
        {
            return new ProductViewModel()
            {
                Product = _productHandler.GetProduct(productId),
                Brands = _dropDownHelper.GetBrandListForDropDown(_brandHandler.GetAllBrands()),
                Countries = _dropDownHelper.GetCountryListForDropDown(_countryHandler.GetCountries())
            };
        }
    }
}

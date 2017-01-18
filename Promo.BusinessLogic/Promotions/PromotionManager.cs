using Promo.BusinessLogic.Companies;
using Promo.BusinessLogic.Countries;
using Promo.Helpers;
using Promo.Model.Models;
using Promo.Model.ViewModels;
using System.Collections.Generic;
using System;
using System.Web.Mvc;
using Promo.BusinessLogic.Brands;
using Promo.Model.HelperModels;

namespace Promo.BusinessLogic.Promotions
{
    public class PromotionManager
    {
        private PromotionHandler _promotionHandler = new PromotionHandler();
        private CompanyHandler _companyHandler = new CompanyHandler();
        private CountryHandler _countryHandler = new CountryHandler();
        private BrandHandler _brandHandler = new BrandHandler();
        private DropDownHelpers _dropDownHelper = new DropDownHelpers();
        private JsonHelper _jsonHelper = new JsonHelper();
        public List<Promotion> GetAllPromotions()
        {
            return _promotionHandler.GetAllPromotions();
        }

        public Promotion GetPromotion(int? promotionId)
        {
            return _promotionHandler.GetPromotion(promotionId);
        }

        public PromotionViewModel GetEmptyPromotion()
        {
            return new PromotionViewModel()
            {
                Companies = _dropDownHelper.GetCompanyListForDropDown(_companyHandler.GetAllCompanies()),
                Countries = _dropDownHelper.GetCountryListForDropDown(_countryHandler.GetCountries())
            };
        }

        public void AddPromotion(Promotion promotion)
        {
            _promotionHandler.AddPromotion(promotion);
        }

        public void EditPromotion(Promotion promotion)
        {
            _promotionHandler.EditPromotion(promotion);
        }

        public PromotionViewModel GetPromotionToEdit(int? promotionId)
        {
            return new PromotionViewModel()
            {
                Promotion = _promotionHandler.GetPromotion(promotionId),
                Companies = _dropDownHelper.GetCompanyListForDropDown(_companyHandler.GetAllCompanies()),
                Countries = _dropDownHelper.GetCountryListForDropDown(_countryHandler.GetCountries())
            };
        }

        

        public int[] GetPromotionBrands(int promotionId)
        {
            return _promotionHandler.GetPromotionBrands(promotionId);
        }

        public void AddPromotionBrands(int promotionId, string[] brandIds)
        {
            foreach (var brandId in brandIds)
            {
                var promotionBrand = new PromotionBrand()
                {
                    PromotionId = promotionId,
                    BrandId = Convert.ToInt32(brandId)
                };
                _promotionHandler.AddPromotionBrand(promotionBrand);
            }
        }
        public void DeletePromotionBrands(int promotionId)
        {
            _promotionHandler.DeletePromotionBrands(promotionId);
        }

        public int[] GetPromotionStores(int promotionId)
        {
            return _promotionHandler.GetPromotionStores(promotionId);
        }

        public void AddPromotionStores(int promotionId, string[] storeIds)
        {
            foreach (var storeId in storeIds)
            {
                var promotionStore = new PromotionStore()
                {
                    PromotionId = promotionId,
                    StoreId = Convert.ToInt32(storeId)
                };
                _promotionHandler.AddPromotionStore(promotionStore);
            }
        }

        public void DeletePromotionStores(int promotionId)
        {
            _promotionHandler.DeletePromotionStores(promotionId);
        }
    }
}
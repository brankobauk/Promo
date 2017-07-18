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
using Promo.Helpers.Dropdowns;
using Promo.Helpers.Json;
using Promo.BusinessLogic.Categories;

namespace Promo.BusinessLogic.Promotions
{
    public class PromotionManager
    {
        private PromotionHandler _promotionHandler = new PromotionHandler();
        private CompanyHandler _companyHandler = new CompanyHandler();
        private CountryHandler _countryHandler = new CountryHandler();
        private CategoryHandler _categoryHandler = new CategoryHandler();
        private BrandHandler _brandHandler = new BrandHandler();
        private DropDownHelpers _dropDownHelper = new DropDownHelpers();
        private JsonHelpers _jsonHelper = new JsonHelpers();
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
                Countries = _dropDownHelper.GetCountryListForDropDown(_countryHandler.GetCountries()),
                Categories = _dropDownHelper.GetCategoryListForDropDown(_categoryHandler.GetAllCategories())
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
                Countries = _dropDownHelper.GetCountryListForDropDown(_countryHandler.GetCountries()),
                Categories = _dropDownHelper.GetCategoryListForDropDown(_categoryHandler.GetAllSortedCategories())
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

        public List<Promotion> GetAllActivePromotions(int? brandId, int? storeId, int? categoryId)
        {
            var promotions =  _promotionHandler.GetAllActivePromotions(brandId, storeId, categoryId);
            var activePromotions = new List<Promotion>();
            var filteredPromotions = new List<Promotion>();
            var filterSet = false;
            if (brandId != null)
            {
                foreach (var promotion in promotions)
                {
                    var brands = _promotionHandler.GetPromotionBrands(promotion.PromotionId);
                    foreach (var brand in brands)
                    {
                        if(brand == brandId)
                        {
                            activePromotions.Add(promotion);
                        }
                    }
                }
                filterSet = true; 
            }
            if (storeId != null)
            {
                if (filterSet == true)
                {
                    filteredPromotions = activePromotions;
                    
                }
                else {
                    filteredPromotions = promotions;
                }

                foreach (var promotion in filteredPromotions)
                {
                    var stores = _promotionHandler.GetPromotionStores(promotion.PromotionId);
                    foreach (var store in stores)
                    {
                        if (store == storeId)
                        {
                            activePromotions.Add(promotion);
                        }
                    }
                }
                filterSet = true;
            }
            if (categoryId != null)
            {
                if (filterSet == true)
                {
                    filteredPromotions = activePromotions;

                }
                else
                {
                    filteredPromotions = promotions;
                }

                foreach (var promotion in filteredPromotions)
                {
                    if (promotion.CategoryId == categoryId)
                    {
                        activePromotions.Add(promotion);
                    }
                }
                filterSet = true;
            }
            if (filterSet == false)
            { 
                return promotions;
            }
            return activePromotions;
        }
    }
}
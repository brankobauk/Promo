using Promo.BusinessLogic.Companies;
using Promo.BusinessLogic.Countries;
using Promo.Helpers;
using Promo.Model.Models;
using Promo.Model.ViewModels;
using System.Collections.Generic;
using System;

namespace Promo.BusinessLogic.Promotions
{
    public class PromotionManager
    {
        private PromotionHandler _promotionHandler = new PromotionHandler();
        private CompanyHandler _companyHandler = new CompanyHandler();
        private CountryHandler _countryHandler = new CountryHandler();
        private DropDownHelpers _dropDownHelper = new DropDownHelpers();
        public List<Promotion> GetAllPromotions()
        {
            return _promotionHandler.GetAllPromotions();
        }

        public Promotion GetPromotion(int? PromotionId)
        {
            return _promotionHandler.GetPromotion(PromotionId);
        }

        public PromotionViewModel GetEmptyPromotion()
        {
            return new PromotionViewModel()
            {
                Companies = _dropDownHelper.GetCompanyListForDropDown(_companyHandler.GetAllCompanies()),
                Countries = _dropDownHelper.GetCountryListForDropDown(_countryHandler.GetCountries())
            };
        }

        public void AddPromotion(Promotion Promotion)
        {
            _promotionHandler.AddPromotion(Promotion);
        }

        public void EditPromotion(Promotion Promotion)
        {
            _promotionHandler.EditPromotion(Promotion);
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
    }
}

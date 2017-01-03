using Promo.BusinessLogic.Companies;
using Promo.DataLayer.Repositories;
using Promo.Helpers;
using Promo.Model.Models;
using Promo.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.BusinessLogic.Stores
{
    public class StoreManager
    {
        private StoreHandler _storeHandler = new StoreHandler();
        private CompanyHandler _companyHandler = new CompanyHandler();
        private DropDownHelpers _dropDownHelper = new DropDownHelpers();
        public List<Store> GetAllStores()
        {
            return _storeHandler.GetAllStores();
        }

        public Store GetStore(int? storeId)
        {
            return _storeHandler.GetStore(storeId);
        }

        public StoreViewModel GetEmptyStore()
        {
            return new StoreViewModel()
            {
                Companies = _dropDownHelper.GetCompanyListForDropDown(_companyHandler.GetAllCompanies())
            };
        }

        public void AddStore(Store store)
        {
            _storeHandler.AddStore(store);
        }

        public void EditStore(Store store)
        {
            _storeHandler.EditStore(store);
        }

        public StoreViewModel GetPromotionToEdit(int? storeId)
        {
            return new StoreViewModel()
            {
                Store = _storeHandler.GetStore(storeId),
                Companies = _dropDownHelper.GetCompanyListForDropDown(_companyHandler.GetAllCompanies())
            };
        }
    }
}

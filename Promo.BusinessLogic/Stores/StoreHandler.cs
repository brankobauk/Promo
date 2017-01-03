using Promo.DataLayer.Repositories;
using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.BusinessLogic.Stores
{
    public class StoreHandler
    {
        private StoreRepository _storeRepository = new StoreRepository();
        public List<Store> GetAllStores()
        {
            return _storeRepository.GetAllStores();
        }

        public Store GetStore(int? storeId)
        {
            return _storeRepository.GetStore(storeId);
        }

        public void AddStore(Store store)
        {
            _storeRepository.AddStore(store);
        }

        public void EditStore(Store store)
        {
            _storeRepository.EditStore(store);
        }
    }
}

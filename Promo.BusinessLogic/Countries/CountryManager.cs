using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.BusinessLogic.Countries
{
    public class CountryManager
    {
        private CountryHandler _countryHandler = new CountryHandler();
        public List<Country> GetCountries()
        {
            return _countryHandler.GetCountries();
        }

        public Country GetCountry(int? countryId)
        {
            return _countryHandler.GetCountry(countryId);
        }

        public void AddCountry(Country country)
        {
            _countryHandler.AddCountry(country);
        }

        public void EditCountry(Country country)
        {
            _countryHandler.EditCountry(country);
        }
    }
}

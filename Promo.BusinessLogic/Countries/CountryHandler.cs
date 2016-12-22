using Promo.DataLayer.Repositories;
using Promo.Model.Models;
using System.Collections.Generic;

namespace Promo.BusinessLogic.Countries
{
    public class CountryHandler
    {
        private CountryRepository _countryRepository = new CountryRepository();
        public List<Country> GetCountries()
        {
            return _countryRepository.GetCountries();
        }

        public Country GetCountry(int? countryId)
        {
            return _countryRepository.GetCountry(countryId);
        }

        public void AddCountry(Country country)
        {
            _countryRepository.AddCountry(country);
        }

        public void EditCountry(Country country)
        {
            _countryRepository.EditCountry(country);
        }
    }
}

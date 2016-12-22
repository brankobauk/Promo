using Promo.Model.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Promo.DataLayer.Repositories
{
    public class CountryRepository
    {
        public List<Country> GetCountries()
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Country.ToList();
            }
        }

        public Country GetCountry(int? CountryId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Country.Find(CountryId);
            }
        }

        public void AddCountry(Country Country)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Country.Add(Country);
                _db.SaveChanges();
            }
        }

        public void EditCountry(Country Country)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Entry(Country).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}

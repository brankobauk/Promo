using Promo.Model.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Promo.DataLayer.Repositories
{
    public class CompanyRepository
    {
        public List<Company> GetAllCompanies()
        { 
            using(var _db = new ApplicationDbContext())
            {
                    return _db.Company.ToList();
            }
        }

        public Company GetCompany(int? CompanyId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Company.Find(CompanyId);
            }
        }

        public void AddCompany(Company Company)
        {
            using (var _db = new ApplicationDbContext())
            {
                 _db.Company.Add(Company);
                _db.SaveChanges();
            }
        }

        public void EditCompany(Company Company)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Entry(Company).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}

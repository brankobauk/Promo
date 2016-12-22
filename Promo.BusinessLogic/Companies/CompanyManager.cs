using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.BusinessLogic.Companies
{
    public class CompanyManager
    {
        private CompanyHandler _companyHandler = new CompanyHandler();
        public List<Company> GetAllCompanies()
        {
            return _companyHandler.GetAllCompanies();
        }

        public Company GetCompany(int? companyId)
        {
            return _companyHandler.GetCompany(companyId);
        }

        public void AddCompany(Company company)
        {
            _companyHandler.AddCompany(company);
        }

        public void EditCompany(Company company)
        {
            _companyHandler.EditCompany(company);
        }
    }
}

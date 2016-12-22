using Promo.DataLayer.Repositories;
using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.BusinessLogic.Companies
{
    public class CompanyHandler
    {
        private CompanyRepository _companyRepository = new CompanyRepository();
        public List<Company> GetAllCompanies()
        {
            return _companyRepository.GetAllCompanies();
        }

        public Company GetCompany(int? companyId)
        {
            return _companyRepository.GetCompany(companyId);
        }

        public void AddCompany(Company company)
        {
            _companyRepository.AddCompany(company);
        }

        public void EditCompany(Company company)
        {
            _companyRepository.EditCompany(company);
        }
    }
}

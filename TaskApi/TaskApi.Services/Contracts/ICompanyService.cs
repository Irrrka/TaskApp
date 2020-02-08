namespace TaskApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskApi.Data.Models;

    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();

        Task<Company> GetCompanyAsync(int companyId);

        Task<int> CreateAsync(Company company);

        //date not change
        Task<bool> UpdateAsync(int companyId, Company company);

        Task<bool> DeleteAsync(int companyId);

        Task<bool> ExistsAsync(int id);
    }
}

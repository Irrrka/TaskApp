namespace TaskApi.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskApi.Data;
    using TaskApi.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class CompanyService : ICompanyService
    {
        private readonly TaskApiDbContext db;

        public CompanyService(TaskApiDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            var all = await this.db
                    .Companies
                    .Include(c => c.Employees)
                    .Include(c => c.Offices)
                    .ToListAsync();
            return all;
        }

        public async Task<Company> GetCompanyAsync(int companyId)
        {
            var current = (await this.GetAllCompaniesAsync())
                              .FirstOrDefault(c => c.Id == companyId);
            return current;
        }

        public async Task<int> CreateAsync(Company company)
        {
            await this.db.Companies.AddAsync(company);
            await this.db.SaveChangesAsync();

            return company.Id;
        }

        public async Task<bool> UpdateAsync(int companyId, Company company)
        {
            var exist = await this.GetCompanyAsync(companyId);
            if (exist == null)
            {
                return false;
            }

            exist.Name = company.Name;
            exist.CreationDate = exist.CreationDate;
            exist.Offices = company.Offices;
            exist.Employees = company.Employees;

            this.db.Companies.Update(exist);
            var result = await this.db.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int companyId)
        {
            var company = await this.GetCompanyAsync(companyId);
            if (company == null)
            {
                return false;
            }

            this.db.Companies.Remove(company);
            var result = await this.db.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ExistsAsync(int companyId)
        {
            return await this.db
                   .Companies
                   .AnyAsync(a => a.Id == companyId);
        }
    }
}

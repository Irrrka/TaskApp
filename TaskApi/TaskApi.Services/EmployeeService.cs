namespace TaskApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskApi.Data;
    using TaskApi.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeService : IEmployeeService
    {
        private readonly TaskApiDbContext db;
        private readonly ICompanyService companyService;

        public EmployeeService(
            TaskApiDbContext db,
            ICompanyService companyService)
        {
            this.db = db;
            this.companyService = companyService;
        }
        //TODO Relocate

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await this.db
                   .Employees
                   .ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            return await this.db
            .Employees
            .FirstOrDefaultAsync(employee => employee.Id == employeeId);
        }


        public async Task<int> CreateAsync(Employee employee)
        {
            var companyExist = await this.companyService.ExistsAsync(employee.CompanyId);
            if (!companyExist)
            {
                return int.MinValue;
            }

            this.db.Employees.Add(employee);
            await this.db.SaveChangesAsync();

            return employee.Id;
        }

        public async Task<bool> UpdateAsync(int employeeId, Employee employee)
        {
            var exists = await this.GetEmployeeAsync(employeeId);
            if (exists == null)
            {
                return false;
            }

            var companyExist = await this.companyService.ExistsAsync(employee.CompanyId);
            if (!companyExist)
            {
                return false;
            }
           
            exists.FirstName = employee.FirstName;
            exists.LastName = employee.LastName;
            exists.Salary = employee.Salary;
            exists.VacationDays = employee.VacationDays;
            exists.CompanyId = employee.CompanyId;
            //exists.OfficeId = employee.OfficeId;
            exists.ExperienceLevel = employee.ExperienceLevel;

            this.db.Employees.Update(employee);
            var result = await this.db.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int employeeId)
        {
            var employee = await this.GetEmployeeAsync(employeeId);
            if (employee == null)
            {
                return false;
            }

            this.db.Employees.Remove(employee);
            var result = await this.db.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ExistsAsync(int employeeId)
        {
            return await this.db
                        .Employees
                        .AnyAsync(employee => employee.Id == employeeId);
        }
    }
}

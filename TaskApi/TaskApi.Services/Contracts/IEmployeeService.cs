namespace TaskApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskApi.Data.Models;

    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeAsync(int employeeId);

        Task<int> CreateAsync(Employee employee);

        Task<bool> UpdateAsync(int employeeId, Employee employee);

        Task<bool> DeleteAsync(int employeeId);

        Task<bool> ExistsAsync(int id);
    }
}

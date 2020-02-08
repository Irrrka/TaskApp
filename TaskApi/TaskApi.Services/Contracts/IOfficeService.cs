namespace TaskApi.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskApi.Data.Models;

    public interface IOfficeService
    {
        Task<IEnumerable<Office>> GetAllOfficesAsync();

        Task<Office> GetOfficeAsync(int officeId);

        Task<int> CreateAsync(Office office);

        Task<bool> UpdateAsync(int officeId, Office office);

        Task<bool> DeleteAsync(int officeId);

        Task<bool> ExistsAsync(int officeId);
    }
}

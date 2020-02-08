namespace TaskApi.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskApi.Data;
    using TaskApi.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class OfficeService : IOfficeService
    {
        private readonly TaskApiDbContext db;

        public OfficeService(TaskApiDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Office>> GetAllOfficesAsync()
        {
            return await this.db.Offices.ToListAsync();
        }

        public async Task<Office> GetOfficeAsync(int officeId)
        {
            return await this.db
            .Offices
            .FirstOrDefaultAsync(office => office.Id == officeId);
        }

        public async Task<int> CreateAsync(Office office)
        {
            //var companyExist = await this.companyService.ExistsAsync(office.CompanyId);
            //if (!companyExist)
            //{
            //    return int.MinValue;
            //}

            this.db.Offices.Add(office);
            await this.db.SaveChangesAsync();

            return office.Id;
        }

        //TODO headquarters may be only one
        public async Task<bool> UpdateAsync(int officeId,Office office)
        {
            var exists = await this.GetOfficeAsync(officeId);
            if (exists == null)
            {
                return false;
            }

            //var companyExists = await this.companyService.ExistsAsync(office.CompanyId);
            //if (!companyExists)
            //{
            //    return false;
            //}

            exists.Country = office.Country;
            exists.City = office.City;
            exists.Street = office.Street;
            exists.StreetNumber = office.StreetNumber;
            exists.Headquarters = office.Headquarters;

            this.db.Offices.Update(office);
            var result = await this.db.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int officeId)
        {
            var office = await this.GetOfficeAsync(officeId);
            if (office == null)
            {
                return false;
            }

            this.db.Offices.Remove(office);
            var result = await this.db.SaveChangesAsync();

            return result > 0;
        }


        public async Task<bool> ExistsAsync(int officeId)
            => await this.db
            .Offices
            .AnyAsync(office => office.Id == officeId);
    }
}

namespace TaskApi.Api.Controllers
{
    using System.Threading.Tasks;
    using TaskApi.Services;
    using Microsoft.AspNetCore.Mvc;
    using TaskApi.Data.Models;

    public class CompaniesController : BaseApiController
    {
        private readonly ICompanyService companyService;

        public CompaniesController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            var copmanies = await this.companyService.GetAllCompaniesAsync();
            if (copmanies==null)
            {
                return this.NotFound();
            }

            return this.Ok(copmanies);
        }

        [HttpGet(WebConstants.ById)]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            var copmany = await this.companyService.GetCompanyAsync(id);
            if (copmany == null)
            {
                return this.NotFound();
            }
            return this.Ok(copmany);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = await this.companyService.CreateAsync(company);

            if (id < 0)
            {
                return this.BadRequest(WebConstants.CompanyNotCreatedErrMsg);
            }

            return this.CreatedAtAction(nameof(Get), new { id }, company);
        }

        [HttpPut(WebConstants.ById)]
        public async Task<IActionResult> Put(int id, Company company)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            var exists = await this.companyService.ExistsAsync(id);
            if (!exists)
            {
                return this.NotFound(WebConstants.CompanyNotFoundErrMsg);
            }

            var isEditable = await this.companyService.UpdateAsync(id, company);
            if (!isEditable)
            {
                return this.BadRequest(WebConstants.CompanyNotUpdatedErrMsg);
            }

            return this.NoContent();
        }

        [HttpDelete(WebConstants.ById)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var exists = await this.companyService.ExistsAsync(id);
            if (!exists)
            {
                return this.NotFound(WebConstants.CompanyNotFoundErrMsg);
            }

            var isDeletable = await this.companyService.DeleteAsync(id);
            if (!isDeletable)
            {
                return this.BadRequest(WebConstants.CompanyNotDeletedErrMsg);
            }

            return this.NoContent();
        }
    }
}
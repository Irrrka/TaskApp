namespace TaskApi.Api.Controllers
{
    using System.Threading.Tasks;
    using TaskApi.Services;
    using Microsoft.AspNetCore.Mvc;
    using TaskApi.Data.Models;

    public class OfficesController : BaseApiController
    {
        private readonly IOfficeService officeService;

        public OfficesController(IOfficeService officeService)
        {
            this.officeService = officeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var offices = await this.officeService.GetAllOfficesAsync();
            if (offices == null)
            {
                return this.NotFound();
            }

            return this.Ok(offices);
        }

        [HttpGet(WebConstants.ById)]
        public async Task<IActionResult> Get(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var exist = await this.officeService.ExistsAsync(id);
            if (!exist)
            {
                return this.NotFound(WebConstants.OfficeNotFoundErrMsg);
            }

            return this.Ok(await this.officeService.GetOfficeAsync(id));
        }

        [HttpDelete(WebConstants.ById)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var exists = await this.officeService.ExistsAsync(id);
            if (!exists)
            {
                return this.NotFound(WebConstants.OfficeNotFoundErrMsg);
            }

            var isDeletable = await this.officeService.DeleteAsync(id);
            if (!isDeletable)
            {
                return this.BadRequest(WebConstants.OfficeNotDeletedErrMsg);
            }

            return this.NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Office office)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var id = await this.officeService.CreateAsync(office);

            if (id < 0)
            {
                return this.NotFound(WebConstants.OfficeNotCreatedErrMsg);
            }

            return this.CreatedAtAction(nameof(Get), new { id }, office);
        }

        [HttpPut(WebConstants.ById)]
        public async Task<IActionResult> Put(int id, Office office)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(WebConstants.InvalidIdMsg);
            }

            var exist = await this.officeService.ExistsAsync(id);
            if (!exist)
            {
                return this.NotFound(WebConstants.OfficeNotFoundErrMsg);
            }

            var isEditable = await this.officeService.UpdateAsync(id, office);
            if (!isEditable)
            {
                return this.BadRequest(WebConstants.OfficeNotUpdatedErrMsg);
            }

            return this.NoContent();
        }
    }
}
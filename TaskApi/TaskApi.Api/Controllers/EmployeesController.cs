namespace TaskApi.Api.Controllers
{
    using System.Threading.Tasks;
    using TaskApi.Services;
    using Microsoft.AspNetCore.Mvc;
    using TaskApi.Data.Models;

    public class EmployeesController : BaseApiController
    {
        private readonly ICompanyService companyService;
        private readonly IEmployeeService employeeService;
        private readonly IOfficeService officeService;

        public EmployeesController(
            ICompanyService companyService,
            IEmployeeService employeeService,
            IOfficeService officeService)
        {
            this.companyService = companyService;
            this.employeeService = employeeService;
            this.officeService = officeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var employees = await this.employeeService.GetAllEmployeesAsync();
            if (employees == null)
            {
                return this.NotFound();
            }

            return this.Ok(employees);
        }


        [HttpGet(WebConstants.ById)]
        public async Task<IActionResult> Get(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var exists = await this.employeeService.ExistsAsync(id);
            if (!exists)
            {
                return this.NotFound(WebConstants.EmployeeNotFoundErrMsg);
            }

            return this.Ok(await this.employeeService.GetEmployeeAsync(id));
        }

        [HttpDelete(WebConstants.ById)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var exists = await this.employeeService.ExistsAsync(id);
            if (!exists)
            {
                return this.NotFound(WebConstants.EmployeeNotFoundErrMsg);
            }

            var isDeletable = await this.employeeService.DeleteAsync(id);
            if (!isDeletable)
            {
                return this.BadRequest(WebConstants.EmployeeNotDeletedErrMsg);
            }

            return this.NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Employee employee)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var id = await this.employeeService.CreateAsync(employee);

            if (id < 0)
            {
                return this.BadRequest(WebConstants.EmployeeNotCreatedErrMsg);
            }

            return this.CreatedAtAction(nameof(Get), new { id }, employee);
        }

        [HttpPut(WebConstants.ById)]
        public async Task<IActionResult> Put(int id, [FromBody]Employee employee)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(WebConstants.InvalidIdMsg);
            }

            var exists = await this.employeeService.ExistsAsync(id);
            if (!exists)
            {
                return this.NotFound(WebConstants.EmployeeNotFoundErrMsg);
            }

            var isUpdatable = await this.employeeService.UpdateAsync(id, employee);

            if (!isUpdatable)
            {
                return this.BadRequest(WebConstants.EmployeeNotUpdatedErrMsg);
            }

            return this.NoContent();
        }

        //TODO
        [HttpPatch(WebConstants.ById)]
        public async Task<IActionResult> Relocate(int id, int officeId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }
            //TODO Relocate
            var exists = await this.employeeService.ExistsAsync(id);
            if (!exists)
            {
                return this.NotFound(WebConstants.EmployeeNotFoundErrMsg);
            }
            var employeeFromDb = await this.employeeService.GetEmployeeAsync(id);
            //employeeFromDb.OfficeId = officeId;

            var isUpdatable = await this.employeeService.UpdateAsync(id, employeeFromDb);

            if (!isUpdatable)
            {
                return this.BadRequest(WebConstants.EmployeeNotUpdatedErrMsg);
            }

            return this.NoContent();
        }
    }
}
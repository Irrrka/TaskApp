namespace TaskApi.Api.Controllers
{
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
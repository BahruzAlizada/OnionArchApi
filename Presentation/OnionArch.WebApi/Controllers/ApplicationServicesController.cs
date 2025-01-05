using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Configurations;

namespace OnionArch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationServicesController : ControllerBase
    {
        private readonly IApplicationService applicationService;
        public ApplicationServicesController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }
        [HttpGet]
        public IActionResult GetAuthorizeDefinitionEndpoints()
        {
            var datas = applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));
            return Ok(datas);
        }
    }
}

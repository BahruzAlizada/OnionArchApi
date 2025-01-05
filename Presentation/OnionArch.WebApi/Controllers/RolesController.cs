using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Constant;
using OnionArch.Application.CustomAttributes;
using OnionArch.Application.Features.Commands.Role.CreateRole;
using OnionArch.Application.Features.Commands.Role.DeleteRole;
using OnionArch.Application.Features.Commands.Role.UpdateRole;
using OnionArch.Application.Features.Queries.Role.GetAllRole;
using OnionArch.Application.Features.Queries.Role.GetByIdRole;
using OnionArch.Domain.Identity;

namespace OnionArch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMediator mediator;
        public RolesController(RoleManager<AppRole> roleManager, IMediator mediator)
        {
            this.roleManager = roleManager;
            this.mediator = mediator;
        }

        #region GetAllRoles
        [HttpGet("GetAllRoles")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = Application.Enums.ActionType.Reading, Definition = "Get All Roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            GetAllRoleQueryResponse getAllRoleQueryResponse = await mediator.Send(new GetAllRoleQueryRequest());
            return Ok(getAllRoleQueryResponse);
        }
        #endregion

        #region GetByIdRole
        [HttpGet("GetByIdRole")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = Application.Enums.ActionType.Reading, Definition = "Get Role by Id")]

        public async Task<IActionResult> GetByIdRole([FromQuery] GetByIdRoleQueryRequest getByIdRoleQueryRequest)
        {
            GetByIdRoleQueryResponse getByIdRoleQueryResponse = await mediator.Send(getByIdRoleQueryRequest);
            return Ok(getByIdRoleQueryResponse);
        }
        #endregion

        #region AddRole
        [HttpPost("AddRole")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = Application.Enums.ActionType.Writing, Definition = "Create Role")]

        public async Task<IActionResult> AddRole([FromBody] CreateRoleCommandRequest createRoleCommandRequest)
        {
            CreateRoleCommandResponse createRoleCommandResponse = await mediator.Send(createRoleCommandRequest);
            return Ok(createRoleCommandResponse);
        }
        #endregion

        #region UpdateRole
        [HttpPut("UpdateRole")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = Application.Enums.ActionType.Updateing, Definition = "Update Role")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            UpdateRoleCommandResponse updateRoleCommandResponse = await mediator.Send(updateRoleCommandRequest);
            return Ok(updateRoleCommandResponse);
        }
        #endregion

        #region DeleteRole
        [HttpDelete("DeleteRole")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = Application.Enums.ActionType.Deleting, Definition = "Delete Role")]
        public async Task<IActionResult> DeleteRole([FromQuery] DeleteRoleCommandRequest deleteRoleCommandRequest)
        {
            DeleteRoleCommandResponse deleteRoleCommandResponse = await mediator.Send(deleteRoleCommandRequest);
            return Ok(deleteRoleCommandResponse);
        }
        #endregion

    }
}

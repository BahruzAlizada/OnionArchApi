using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Constant;
using OnionArch.Application.CustomAttributes;
using OnionArch.Application.Features.Commands.User.CreateUser;
using OnionArch.Application.Features.Commands.User.LoginUser;
using OnionArch.Application.Features.Commands.User.UpdateUser;
using OnionArch.Application.Features.Queries.User.GetAllUser;
using OnionArch.Application.Features.Queries.User.GetByIdUser;
using OnionArch.Domain.Identity;

namespace OnionArch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly SignInManager<AppUser> signInManager;
        public UsersController(IMediator mediator, SignInManager<AppUser> signInManager)
        {
            this.mediator = mediator;
            this.signInManager = signInManager;
        }


        #region GetAllUser
        [HttpGet("GetAllUser")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = Application.Enums.ActionType.Reading, Definition = "Get All Users")]
        public async Task<IActionResult> GetAllUser([FromQuery] GetAllUserQueryRequest getAllUserQueryRequest)
        {
            GetAllUserQueryResponse getAllUserQueryResponse = await mediator.Send(getAllUserQueryRequest);
            return Ok(getAllUserQueryResponse);
        }
        #endregion

        #region GetByIdUser
        [HttpGet("GetByIdUser")]
        public async Task<IActionResult> GetByIdUser([FromQuery] GetByIdUserQueryRequest getByIdUserQueryRequest)
        {
            GetByIdUserQueryResponse getByIdUserQueryResponse = await mediator.Send(getByIdUserQueryRequest);
            return Ok(getByIdUserQueryResponse);
        }
        #endregion

        #region CreateUser
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse createUserCommandResponse = await mediator.Send(createUserCommandRequest);
            return Ok(createUserCommandResponse);
        }
        #endregion

        #region UpdateUser
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest updateUserCommandRequest)
        {
            UpdateUserCommandResponse updateUserCommandResponse = await mediator.Send(updateUserCommandRequest);
            return Ok(updateUserCommandResponse);
        }
        #endregion

        #region LoginUser
        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommandRequest loginUserCommandRequest)
        {
            var responspe = await mediator.Send(loginUserCommandRequest);
            return Ok(responspe);
        }
        #endregion

        #region Logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }
        #endregion
    }
}

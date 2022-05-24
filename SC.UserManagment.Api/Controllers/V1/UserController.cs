using Mapster;
using Microsoft.AspNetCore.Mvc;
using SC.Common.CQRS;
using SC.UserManagment.Application.Commands.CreateUser;
using SC.UserManagment.Application.Commands.DeleteUser;
using SC.UserManagment.Application.Commands.UpdateUser;
using SC.UserManagment.Application.Errors;
using SC.UserManagment.Application.Models.CQRS.User;
using SC.UserManagment.Application.Models.V1.User;
using SC.UserManagment.Application.Queries.GetUser;
using SC.UserManagment.Application.Queries.GetUsers;
using System.ComponentModel.DataAnnotations;

namespace SC.UserManagment.Api.Controllers.V1;

/// <summary>
/// 
/// </summary>
[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UserController : ControllerBase
{
  /// <summary>
  /// 
  /// </summary>
  private readonly IDispatcher _dispatcher;

  /// <summary>
  /// 
  /// </summary>
  /// <param name="dispatcher"></param>
  public UserController(IDispatcher dispatcher)
  {
    _dispatcher = dispatcher;
  }
  /// <summary>
  /// Test de GET
  /// </summary>
  /// <returns></returns>
  [HttpGet]
  [Produces("application/json")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUsersResultModel))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponseResultModel))]
  public async Task<IActionResult> GetAllUsers()
  {
    return Ok(await _dispatcher.GetResultAsync<GetUsersQuery, GetUsersResultModel>(new GetUsersQuery()));
  }


  /// <summary>
  /// Create user in AzureTable
  /// </summary>
  /// <returns></returns>
  [HttpPost]
  [Produces("application/json")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateUserResultModel))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponseResultModel))]
  public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
  {
    var command = new CreateUserCommand()
    {
      User = dto.Adapt<User>()
    };
    return Ok(await _dispatcher.SendAsync<CreateUserCommand, CreateUserResultModel>(command));
  }


  /// <summary>
  /// Test de GET
  /// </summary>
  /// <returns></returns>
  [HttpGet("{guid}")]
  [Produces("application/json")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserResultModel))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponseResultModel))]
  public async Task<IActionResult> GetUser([FromRoute, Required] Guid guid)
  {
    return Ok(await _dispatcher.GetResultAsync<GetUserQuery, GetUserResultModel>(new GetUserQuery() { Guid = guid }));
  }

  /// <summary>
  /// Update user in AzureTable
  /// </summary>
  /// <returns></returns>
  [HttpPut("{guid}")]
  [Produces("application/json")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateUserResultModel))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponseResultModel))]
  public async Task<IActionResult> UpdateUser([FromRoute, Required] Guid guid, [FromBody, Required] UpdateUserDto dto)
  {
    var command = new UpdateUserCommand()
    {
      User = dto.Adapt<User>()
    };
    command.User.UserId = guid;
    return Ok(await _dispatcher.SendAsync<UpdateUserCommand, UpdateUserResultModel>(command));
  }


  /// <summary>
  /// Delete user in AzureTable
  /// </summary>
  /// <returns></returns>
  [HttpDelete("{guid}")]
  [Produces("application/json")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteUserResultModel))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponseResultModel))]
  public async Task<IActionResult> DeleteUser([FromRoute, Required] Guid guid)
  {
    return Ok(await _dispatcher.SendAsync<DeleteUserCommand, DeleteUserResultModel>(new DeleteUserCommand() { Guid = guid }));
  }

}

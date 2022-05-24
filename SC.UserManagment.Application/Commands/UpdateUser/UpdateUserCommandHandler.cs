using SC.Common.CQRS.Commands;
using SC.Common.CQRS.Events;
using SC.UserManagment.Application.Models.V1.User;
using SC.UserManagment.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.UserManagment.Application.Commands.UpdateUser
{
  /// <summary>
  /// 
  /// </summary>
  public class UpdateUserCommandHandler : ICommandHandlerAsync<UpdateUserCommand, UpdateUserResultModel>
  {
    private readonly IUserService _userService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    public UpdateUserCommandHandler(IUserService userService)
    {
      _userService = userService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public async Task<CommandResult<UpdateUserResultModel>> HandleAsync(UpdateUserCommand command)
    {
      var res = await _userService.UpdateUserAsync(command.User);
      return new CommandResult<UpdateUserResultModel>(res, null);
    }
  }
}

using SC.Common.CQRS.Commands;
using SC.Common.CQRS.Events;
using SC.UserManagment.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.UserManagment.Application.Commands.DeleteAllUsers
{
  /// <summary>
  /// 
  /// </summary>
  public class DeleteAllUsersCommandHandler : ICommandHandlerAsync<DeleteAllUsersCommand>
  {
    private readonly IUserService _userService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    public DeleteAllUsersCommandHandler(IUserService userService)
    {
      _userService = userService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public async Task<IEnumerable<IEvent>> HandleAsync(DeleteAllUsersCommand command)
    {
      await _userService.DeleteUsersAsync();
      return null;
    }
  }
}

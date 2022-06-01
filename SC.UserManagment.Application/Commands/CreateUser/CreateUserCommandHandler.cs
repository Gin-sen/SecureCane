using SC.Common.CQRS.Commands;
using SC.Common.CQRS.Events;
//using SC.UserManagment.Application.Events.UserCreated;
//using SC.UserManagment.Application.Models.CQRS.TransactionalEmail;
//using SC.UserManagment.Application.Models.CQRS.User;
using SC.UserManagment.Application.Models.V1.User;
using SC.UserManagment.Application.Repositories;
using SC.UserManagment.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.UserManagment.Application.Commands.CreateUser
{
  /// <summary>
  /// 
  /// </summary>
  public class CreateUserCommandHandler : ICommandHandlerAsync<CreateUserCommand, CreateUserResultModel>
  {
    /// <summary>
    /// 
    /// </summary>
    private readonly IUserService _userService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    public CreateUserCommandHandler(IUserService userService)
    {
      _userService = userService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public async Task<CommandResult<CreateUserResultModel>> HandleAsync(CreateUserCommand command)
    {
      var result = await _userService.CreateUserAsync(command.User);
/*      var e = new UserCreatedEvent() { UserId = result.UserId,
        Transaction = new SimpleTransaction 
        {
          Sender = new Sender
          {
            Name = "SecureCane",
            Email = "no-reply@securecane.net"
          },
          To = new List<SendTo>
          {
            new SendTo 
            {
              Email = command.User.Mail,
              Name = $"{command.User.FirstName} {command.User.LastName}"
            }
          }
        }
      };
      return new CommandResult<CreateUserResultModel>(result, e);*/
      return new CommandResult<CreateUserResultModel>(result);
    }
  }
}

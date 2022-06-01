using SC.Common.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SC.UserManagment.Application.Commands.DeleteUser
{
  /// <summary>
  /// 
  /// </summary>
  public class DeleteUserCommand : ICommand
  {

    /// <summary>
    /// 
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Guid GroupId { get; set; }
  }
}

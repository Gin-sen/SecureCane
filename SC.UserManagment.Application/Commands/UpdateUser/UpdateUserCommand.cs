using SC.Common.CQRS.Commands;
using SC.UserManagment.Application.Models.CQRS.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace SC.UserManagment.Application.Commands.UpdateUser
{
  /// <summary>
  /// 
  /// </summary>
  public class UpdateUserCommand : ICommand
  {
    /// <summary>
    /// 
    /// </summary>
    public User User { get; set; }
  }
}

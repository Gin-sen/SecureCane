using SC.Common.CQRS.Commands;
using SC.UserManagment.Application.Models.CQRS.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace SC.UserManagment.Application.Commands.CreateUser
{
  /// <summary>
  /// 
  /// </summary>
  public class CreateUserCommand : ICommand
  {
    /// <summary>
    /// 
    /// </summary>
    public User User { get; set; }
  }
}

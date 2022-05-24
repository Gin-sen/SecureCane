using System;
using System.Collections.Generic;
using System.Text;

namespace SC.UserManagment.Application.Models.Enum
{
  /// <summary>
  /// 
  /// </summary>
  public enum UserType
  {
    /// <summary>
    /// User is Admin
    /// </summary>
    Admin = 0,
    /// <summary>
    /// User is a classic User
    /// </summary>
    User = 1,
    /// <summary>
    /// User is a relative to a User
    /// </summary>
    Relative = 2
  }
}

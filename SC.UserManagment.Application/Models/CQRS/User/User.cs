using System;
using System.Collections.Generic;
using System.Text;

namespace SC.UserManagment.Application.Models.CQRS.User
{
  /// <summary>
  /// 
  /// </summary>
  public class User
  {
    /// <summary>
    /// UserId
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Login
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// Login
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Mail
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// FirstName
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// LastName
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Status (ex : 0 = toComfirm, 1 = Activ, 2 = Locked)
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime UpdatedAt { get; set; }
  }
}

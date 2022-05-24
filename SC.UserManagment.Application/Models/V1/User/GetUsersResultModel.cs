using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SC.UserManagment.Application.Models.V1.User
{
  /// <summary>
  /// 
  /// </summary>
  public class GetUsersResultModel
  {
    /// <summary>
    /// 
    /// </summary>
    public List<GetUserResultModel> Users { get; set; }

  
  }
}

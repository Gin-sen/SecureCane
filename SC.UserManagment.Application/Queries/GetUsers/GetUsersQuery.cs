using SC.Common.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SC.UserManagment.Application.Queries.GetUsers
{
  /// <summary>
  /// 
  /// </summary>
  public class GetUsersQuery : IQuery
  {

    /// <summary>
    /// 
    /// </summary>
    public Guid GroupId { get; set; }
  }
}

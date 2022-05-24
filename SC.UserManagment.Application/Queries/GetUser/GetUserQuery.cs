using SC.Common.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SC.UserManagment.Application.Queries.GetUser
{
  /// <summary>
  /// 
  /// </summary>
  public class GetUserQuery : IQuery
  {
    /// <summary>
    /// 
    /// </summary>
    public Guid Guid { get; set; }
  }
}

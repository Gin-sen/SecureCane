using SC.Common.CQRS.Queries;
using SC.UserManagment.Application.Models.V1.User;
using SC.UserManagment.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.UserManagment.Application.Queries.GetUser
{
  /// <summary>
  /// 
  /// </summary>
  public class GetUserQueryHandler : IQueryHandlerAsync<GetUserQuery, GetUserResultModel>
  {

    private readonly IUserService _userService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    public GetUserQueryHandler(IUserService userService)
    {
      _userService = userService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<GetUserResultModel> RetrieveAsync(GetUserQuery query)
    {
      return await _userService.GetUserAsync(query.Guid);
    }
  }
}

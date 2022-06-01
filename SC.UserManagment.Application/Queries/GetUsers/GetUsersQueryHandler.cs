using SC.Common.CQRS.Queries;
using SC.UserManagment.Application.Models.V1.User;
using SC.UserManagment.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.UserManagment.Application.Queries.GetUsers
{
  /// <summary>
  /// 
  /// </summary>
  public class GetUsersQueryHandler : IQueryHandlerAsync<GetUsersQuery, GetUsersResultModel>
  {

    private readonly IUserService _userService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    public GetUsersQueryHandler(IUserService userService)
    {
      _userService = userService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<GetUsersResultModel> RetrieveAsync(GetUsersQuery query)
    {
      return await _userService.GetUsersAsync(query.GroupId);
    }
  }
}

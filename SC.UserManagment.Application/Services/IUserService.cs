using SC.UserManagment.Application.Models.CQRS.User;
using SC.UserManagment.Application.Models.V1.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.UserManagment.Application.Services
{
  /// <summary>
  /// 
  /// </summary>
  public interface IUserService
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<CreateUserResultModel> CreateUserAsync(User user);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<GetUserResultModel> GetUserAsync(Guid groupId, Guid userId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="groupId"></param>
    /// <returns></returns>
    Task<GetUsersResultModel> GetUsersAsync(Guid groupId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<UpdateUserResultModel> UpdateUserAsync(User user);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<DeleteUserResultModel> DeleteUserAsync(Guid groupId, Guid userId);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task DeleteUsersAsync();
  }
}

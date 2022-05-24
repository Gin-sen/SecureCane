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
    /// <param name="guid"></param>
    /// <returns></returns>
    Task<GetUserResultModel> GetUserAsync(Guid guid);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<GetUsersResultModel> GetUsersAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<UpdateUserResultModel> UpdateUserAsync(User user);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    Task<DeleteUserResultModel> DeleteUserAsync(Guid guid);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task DeleteUsersAsync();
  }
}

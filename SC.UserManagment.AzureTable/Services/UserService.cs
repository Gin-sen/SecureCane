using SC.UserManagment.Application.Models.CQRS.User;
using SC.UserManagment.Application.Models.V1.User;
using SC.UserManagment.Application.Repositories;
using SC.UserManagment.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.UserManagment.AzureTable.Services
{
  /// <summary>
  /// Exécute la logique 
  /// </summary>
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userRepository"></param>
    public UserService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<CreateUserResultModel> CreateUserAsync(User user)
    {
      var res = await _userRepository.CreateUserAsync(user);
      return null;

    }

    public Task<DeleteUserResultModel> DeleteUserAsync(Guid guid)
    {
      throw new NotImplementedException();
    }

    public Task DeleteUsersAsync()
    {
      throw new NotImplementedException();
    }

    public Task<GetUserResultModel> GetUserAsync(Guid guid)
    {
      throw new NotImplementedException();
    }

    public Task<GetUsersResultModel> GetUsersAsync()
    {
      throw new NotImplementedException();
    }

    public Task<UpdateUserResultModel> UpdateUserAsync(User user)
    {
      throw new NotImplementedException();
    }
  }
}

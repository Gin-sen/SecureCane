using SC.UserManagment.Application.Models.CQRS.User;
using SC.UserManagment.Application.Repositories;
using SC.UserManagment.AzureTable.Entities;
using SC.UserManagment.AzureTable.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.UserManagment.AzureTable.Repositories
{
  /// <summary>
  /// 
  /// </summary>
  public class UserRepository : IUserRepository
  {

    private readonly IUserTable _userTable;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userTable"></param>
    public UserRepository(IUserTable userTable)
    {
      _userTable = userTable;
    }

    public async Task<User> CreateUserAsync(User user)
    {
      UserEntity entity = new UserEntity(DateTimeOffset.UtcNow, user.CreatedAt, new Azure.ETag(), user.Email, user.FirstName);
      await _userTable.UpsertEntityAsync(entity);
      return null;
    }

    public Task DeleteAllUsersAsync()
    {
      throw new NotImplementedException();
    }

    public Task<User> DeleteUserAsync(Guid guid)
    {
      throw new NotImplementedException();
    }

    public Task<User> GetUserAsync(Guid guid)
    {
      throw new NotImplementedException();
    }

    public Task<List<User>> GetUsersAsync()
    {
      throw new NotImplementedException();
    }

    public Task<bool> IsExistAsync(Guid guid)
    {
      throw new NotImplementedException();
    }

    public Task<bool> IsExistByLoginAsync(string login)
    {
      throw new NotImplementedException();
    }

    public Task<User> UpdateUserAsync(User user)
    {
      throw new NotImplementedException();
    }
  }
}

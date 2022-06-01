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
      UserEntity entity = new UserEntity(user.GroupId, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, user.Email, user.FirstName, user.LastName,user.Login, user.Phone);
      await _userTable.UpsertEntityAsync(entity);
      user.GroupId = Guid.Parse(entity.PartitionKey);
      user.UserId = Guid.Parse(entity.RowKey);
      return user;
    }

    public Task DeleteAllUsersAsync()
    {
      throw new NotImplementedException();
    }

    public Task<User> DeleteUserAsync(string groupId, string userId)
    {
      throw new NotImplementedException();
    }

    public async Task<User> GetUserAsync(string groupId, string userId)
    {
      var res = await _userTable.GetEntityAsync(userId, groupId);
      return new User()
      {
        GroupId = Guid.Parse(res.PartitionKey),
        UserId = Guid.Parse(res.RowKey),
        Login = res.Login,
        Email = res.Email,
        Phone = res.Phone,
        FirstName = res.FirstName,
        LastName = res.LastName,
        CreatedAt = res.CreatedAt,
        UpdatedAt = res.Timestamp
      };
    }

    public async Task<List<User>> GetUsersAsync(string groupId)
    {
      var res = await _userTable.GetEntitiesAsync(groupId);
      List<User> users = new List<User>();
      foreach (UserEntity userEntity in res)
      {
        users.Add(new User()
        {
          GroupId = Guid.Parse(userEntity.PartitionKey),
          UserId = Guid.Parse(userEntity.RowKey),
          Login = userEntity.Login,
          Email = userEntity.Email,
          Phone = userEntity.Phone,
          FirstName = userEntity.FirstName,
          LastName = userEntity.LastName,
          CreatedAt = userEntity.CreatedAt,
          UpdatedAt = userEntity.Timestamp
        });
      }
      return users;
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

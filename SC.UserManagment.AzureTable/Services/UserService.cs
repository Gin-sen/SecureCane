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
      User res = await _userRepository.CreateUserAsync(user);
      return new CreateUserResultModel()
      {
        UserId = res.UserId,
        GroupId = res.GroupId
      };

    }

    public Task<DeleteUserResultModel> DeleteUserAsync(Guid groupId, Guid userId)
    {
      throw new NotImplementedException();
    }

    public Task DeleteUsersAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<GetUserResultModel> GetUserAsync(Guid groupId, Guid userId)
    {
      var res = await _userRepository.GetUserAsync(groupId.ToString(), userId.ToString());
      return new GetUserResultModel()
      {
        GroupId = res.GroupId,
        UserId = res.UserId,
        Login = res.Login,
        Email = res.Email,
        Phone = res.Phone,
        FirstName = res.FirstName,
        LastName = res.LastName,
        CreatedAt = res.CreatedAt,
        UpdatedAt = res.UpdatedAt
      };
    }

    public async Task<GetUsersResultModel> GetUsersAsync(Guid groupId)
    {
      var res = await _userRepository.GetUsersAsync(groupId.ToString());
      GetUsersResultModel resultModel = new GetUsersResultModel()
      {
        Users = new List<GetUserResultModel>()
      };
      foreach(User user in res)
      {
        resultModel.Users.Add(new GetUserResultModel()
        {
          GroupId = user.GroupId,
          UserId = user.UserId,
          Login = user.Login,
          Email = user.Email,
          Phone = user.Phone,
          FirstName = user.FirstName,
          LastName = user.LastName,
          CreatedAt = user.CreatedAt,
          UpdatedAt = user.UpdatedAt
        });
      }
      return resultModel;
    }

    public Task<UpdateUserResultModel> UpdateUserAsync(User user)
    {
      throw new NotImplementedException();
    }
  }
}

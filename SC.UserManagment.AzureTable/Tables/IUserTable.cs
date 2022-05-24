using SC.UserManagment.AzureTable.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.UserManagment.AzureTable.Tables
{
  public interface IUserTable
  {
    Task<List<UserEntity>> GetEntitiesAsync(string userId, string groupId);
    Task<UserEntity> GetEntityAsync(string userId, string groupId);
    Task<UserEntity> UpsertEntityAsync(UserEntity entity);
    Task DeleteEntityAsync(string id);
  }
}

using Azure;
using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using SC.Common.AzureTable;
using SC.Common.AzureTables;
using SC.UserManagment.AzureTable.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.UserManagment.AzureTable.Tables
{
  public class UserTable : BaseTable<UserEntity>, IUserTable
  {
    public UserTable(string tableName, string storageConnectionString)
      : base(tableName, storageConnectionString) { }

    public async Task DeleteEntityAsync(string userId, string groupId)
    {
      var tableClient = await GetTableClient();
      await tableClient.DeleteEntityAsync(groupId, userId);
    }

    public async Task<List<UserEntity>> GetEntitiesAsync(string groupId)
    {
      var tableClient = await GetTableClient();
      AsyncPageable<UserEntity> awaitableResult = tableClient.QueryAsync<UserEntity>(TableClient.CreateQueryFilter($"PartitionKey eq {groupId}"));
      List<UserEntity> result = new List<UserEntity>();
      await foreach (UserEntity user in awaitableResult)
      {
        result.Add(user);
      }
      return result;
    }


    public async Task<UserEntity> GetEntityAsync(string userId, string groupId)
    {
      var tableClient = await GetTableClient();
      var awaitableResult = await tableClient.GetEntityAsync<UserEntity>(groupId, userId);
      return awaitableResult.Value;
    }

    public async Task<UserEntity> UpsertEntityAsync(UserEntity entity)
    {
      await InsertOrUpdateEntityAsync(entity);
      return entity;
    }
  }
}

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

    public Task DeleteEntityAsync(string id)
    {
      throw new NotImplementedException();
    }

    public async Task<List<UserEntity>> GetEntitiesAsync(string userId, string groupId)
    {
      var tableClient = await GetTableClient();
      var awaitableResult = tableClient.QueryAsync<UserEntity>($"PartitionKey -eq {groupId} && RowKey -eq {userId}");
      CancellationToken cancellationToken = default;
      var res = awaitableResult.AsPages().GetAsyncEnumerator(cancellationToken);

      List<UserEntity> arrayRes = new List<UserEntity>();
      do
      {
        foreach (var e in res.Current.Values.ToArray())
          arrayRes.Append(e);
        if (res.Current.ContinuationToken != null)
          break;
        await res.MoveNextAsync();
      } while (res.Current.ContinuationToken != null);
      return null;
    }


    public async Task<UserEntity> GetEntityAsync(string userId, string groupId)
    {
      var tableClient = await GetTableClient();
      var awaitableResult = tableClient.QueryAsync<UserEntity>($"PartitionKey -eq {groupId} && RowKey -eq {userId}");
      CancellationToken cancellationToken = default;
      var res = awaitableResult.AsPages().GetAsyncEnumerator(cancellationToken);

      List<UserEntity> arrayRes = new List<UserEntity>();
      do
      {
        foreach (var e in res.Current.Values.ToArray())
          arrayRes.Append(e);
        if (res.Current.ContinuationToken != null)
          break;
        await res.MoveNextAsync();
      } while (res.Current.ContinuationToken != null);
      return null;
    }

    public async Task<UserEntity> UpsertEntityAsync(UserEntity entity)
    {
      await InsertOrUpdateEntityAsync(entity);
      return entity;
    }
  }
}

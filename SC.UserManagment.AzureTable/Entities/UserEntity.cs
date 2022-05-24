using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.UserManagment.AzureTable.Entities
{
  public class UserEntity : ITableEntity
  {
    public UserEntity(){}
    public UserEntity(DateTimeOffset? timestamp, DateTimeOffset? createdAt, ETag eTag, string email, string name)
    {
      PartitionKey = Guid.NewGuid().ToString();
      RowKey = Guid.NewGuid().ToString();
      Timestamp = timestamp;
      CreatedAt = createdAt;
      ETag = eTag;
      Email = email;
      Name = name;
    }
    /// <summary>
    /// Id Canne/Groupe
    /// </summary>
    public string PartitionKey { get; set; }
    /// <summary>
    /// Id User
    /// </summary>
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public ETag ETag { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
  }
}

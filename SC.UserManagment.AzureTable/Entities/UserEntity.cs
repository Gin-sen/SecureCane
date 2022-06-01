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

    public UserEntity(Guid groupId, DateTimeOffset? timestamp, DateTimeOffset? createdAt, string email, string firstname, string lastname, string login, string phone)
    {
      PartitionKey = groupId.Equals(Guid.Empty) ? Guid.NewGuid().ToString() : groupId.ToString();
      RowKey = Guid.NewGuid().ToString();
      Timestamp = timestamp;
      CreatedAt = createdAt;
      Login = login;
      Email = email;
      FirstName = firstname;
      LastName = lastname;
      Phone = phone;
    }

    /// <summary>
    /// Id Canne/Groupe
    /// </summary>
    public string PartitionKey { get; set; }
    /// <summary>
    /// Id User
    /// </summary>
    public string RowKey { get; set; }

    /// <summary>
    /// UpdatedAt
    /// </summary>
    public DateTimeOffset? Timestamp { get; set; }
    
    /// <summary>
    /// CreatedAt
    /// </summary>
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// Tag de concurence d'entité (géré par les tables)
    /// </summary>
    public ETag ETag { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Prénom
    /// </summary>
    public string FirstName { get; set; }


    /// <summary>
    /// Nom
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Login
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// Phone
    /// </summary>
    public string Phone { get; set; }
  }
}

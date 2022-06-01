using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SC.UserManagment.Application.Models.V1.User
{
  /// <summary>
  /// 
  /// </summary>
  public class GetUserResultModel
  {
    /// <summary>
    /// UserId
    /// </summary>
    [JsonPropertyName("groupId")]
    public Guid GroupId { get; set; }
    /// <summary>
    /// UserId
    /// </summary>
    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }

    /// <summary>
    /// Login
    /// </summary>
    [JsonPropertyName("login")]
    public string Login { get; set; }
    /// <summary>
    /// Mail
    /// </summary>
    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    /// <summary>
    /// Mail
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// FirstName
    /// </summary>
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// LastName
    /// </summary>
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    /// <summary>
    /// Status (ex : 0 = toComfirm, 1 = Activ, 2 = Locked)
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTimeOffset? UpdatedAt { get; set; }
  }
}

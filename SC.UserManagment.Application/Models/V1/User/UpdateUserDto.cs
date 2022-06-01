using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace SC.UserManagment.Application.Models.V1.User
{
  /// <summary>
  /// 
  /// </summary>
  public class UpdateUserDto
  {
    /*/// <summary>
    /// Login 
    /// </summary>
    [JsonPropertyName("login")]
    public string Login { get; set; }*/
    /// <summary>
    /// Mail
    /// </summary>
    [JsonPropertyName("phone")]
    [Phone]
    public string Phone { get; set; }
    /// <summary>
    /// Mail
    /// </summary>
    [JsonPropertyName("mail")]
    [EmailAddress]
    [StringLength(75)]
    public string Mail { get; set; }

    /// <summary>
    /// FirstName
    /// </summary>
    [JsonPropertyName("firstName")]
    [StringLength(20)]
    public string FirstName { get; set; }

    /// <summary>
    /// LastName
    /// </summary>
    [JsonPropertyName("lastName")]
    [StringLength(20)]
    public string LastName { get; set; }

    /// <summary>
    /// LastName
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

  }
}

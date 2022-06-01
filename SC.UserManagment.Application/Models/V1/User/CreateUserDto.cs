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
  public class CreateUserDto
  {

    /// <summary>
    /// Login
    /// </summary>
    [JsonPropertyName("groupId")]
    [StringLength(64)]
    public string? GroupId { get; set; }

    /// <summary>
    /// Login
    /// </summary>
    [JsonPropertyName("login")]
    [Required]
    [StringLength(64)]
    public string Login { get; set; }

    /// <summary>
    /// Phone
    /// </summary>
    [JsonPropertyName("phone")]
    [Required]
    [Phone]
    public string Phone { get; set; }

    /// <summary>
    /// Mail
    /// </summary>
    [JsonPropertyName("email")]
    [Required]
    [EmailAddress]
    [StringLength(120)]
    public string Email { get; set; }

    /// <summary>
    /// FirstName
    /// </summary>
    [JsonPropertyName("firstName")]
    [Required]
    //[StringLength(20)]
    public string FirstName { get; set; }

    /// <summary>
    /// LastName
    /// </summary>
    [JsonPropertyName("lastName")]
    [Required]
    //[StringLength(20)]
    public string LastName { get; set; }
  }
}

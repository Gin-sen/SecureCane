using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SC.UserManagment.Application.Errors
{
  /// <summary>
  /// Détail d'erreur
  /// </summary>
  public class ErrorDetailResultModel
  {
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string Code { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string Message { get; set; }
  }
}

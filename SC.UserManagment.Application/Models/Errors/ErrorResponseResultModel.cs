using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SC.UserManagment.Application.Errors
{
  /// <summary>
  /// Object to return for an error
  /// </summary>
  public class ErrorResponseResultModel
  {
    /// <summary>
    /// Error title
    /// Use localization if possible
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// Error message
    /// Use localization if possible
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// Error type
    /// </summary>
    [JsonPropertyName("errorType")]
    public string ErrorType { get; set; }

    /// <summary>
    /// List of inner errors
    /// </summary>
    [JsonPropertyName("errors")]
    public List<ErrorDetailResultModel> Errors { get; set; } = new List<ErrorDetailResultModel>();

    /// <summary>
    /// Informations on which micro-service
    /// the error comes from
    /// </summary>
    [JsonPropertyName("origin")]
    public string Origin { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SC.UserManagment.Application.Errors
{
  /// <summary>
  /// List of error messages to return to the client
  /// using localization if possible
  /// </summary>
  public class ErrorMessage
  {
    /// <summary>
    /// 
    /// </summary>
    protected ErrorMessage()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public const string ErrorMiddleware = "ERROR_MIDDLEWARE";

    /// <summary>
    /// 
    /// </summary>
    public const string InvalidModel = "MODEL_INVALID";

    /// <summary>
    /// 
    /// </summary>
    public const string UserNotFound = "USER_NOT_FOUND";

    /// <summary>
    /// 
    /// </summary>
    public const string InternalServerError = "INTERNAL_SERVER_ERROR";

    /// <summary>
    /// 
    /// </summary>
    public const string UserUnauthorized = "EBP_TRAITEMENT_UNAUTHORIZED";

    /// <summary>
    /// 
    /// </summary>
    public const string BasicAuthentication = "BASIC_AUTHENTICATION_ERROR";

    /// <summary>
    /// 
    /// </summary>
    public const string BearerAuthentication = "BEARER_AUTHENTICATION_ERROR";

    /// <summary>
    /// 
    /// </summary>
    public const string ApiKeyAuthentication = "APIKEY_AUTHENTICATION_ERROR";

    /// <summary>
    /// 
    /// </summary>
    public const string ApiKeyNotProvided = "APIKEY_NOT_PROVIDED_ERROR";
  }
}

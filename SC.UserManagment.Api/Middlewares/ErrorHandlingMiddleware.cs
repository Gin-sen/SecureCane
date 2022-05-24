

using SC.UserManagment.Application.Errors;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace SC.UserManagment.Api.Middlewares
{
  /// <summary>
  /// Custom middleware
  /// </summary>
  public class ErrorHandlingMiddleware
  {

    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
      _next = next;
      _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch (Exception ex)
      {
        await CatchException(httpContext, ex);
      }
    }


    private async Task CatchException(HttpContext httpContext, Exception ex)
    {


      httpContext.Response.ContentType = "application/json";
      httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

      ErrorResponseResultModel errorResponse = new ErrorResponseResultModel
      {
        Title = "Unhandled Exception",
        Message = "Something wrong happened",
        Origin = "UserManagementAPI",
        ErrorType = ErrorTypes.ErrorMiddleware
      };
      if (IsValidStackTrace(ex))
        errorResponse.Errors.Add(new ErrorDetailResultModel
        {
          Code = "EXCEPTION",
          Message = ex.StackTrace!,
        });
      
      await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
      _logger.LogCritical(ex, $"{httpContext.Request.Path.Value} Exception");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static bool IsValidStackTrace([NotNullWhen(true)] Exception? ex)
    => ex is not null && ex.StackTrace is not null;
  }

  /// <summary>
  /// 
  /// </summary>
  public static class ErrorHandlingMiddlewareExtensions
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseErrorHandlingMiddleware(
        this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<ErrorHandlingMiddleware>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseErrorHandlingMiddlewareWhenNot(
        this IApplicationBuilder builder, string urlPath)
    {
      return builder.UseWhen(
       httpContext => !httpContext.Request.Path.StartsWithSegments(urlPath),
       subApp => subApp.UseMiddleware(typeof(ErrorHandlingMiddleware)));
    }
  }
}

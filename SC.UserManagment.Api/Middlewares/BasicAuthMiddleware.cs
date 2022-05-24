using Microsoft.Extensions.Localization;
using System.Text.Json;

namespace SC.UserManagment.Api.Middlewares
{
  /// <summary>
  /// 
  /// </summary>
  public class BasicAuthMiddleware
  {
    private readonly ILogger<BasicAuthMiddleware> _logger;

    private readonly RequestDelegate _next;

    private readonly IStringLocalizer<BasicAuthMiddleware> _localizer;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="localizer"></param>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public BasicAuthMiddleware(IStringLocalizer<BasicAuthMiddleware> localizer, RequestDelegate next, ILogger<BasicAuthMiddleware> logger)
    {
      _localizer = localizer;
      _next = next;
      _logger = logger;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        await CatchException(context, ex);
      }
    }


    private async Task CatchException(HttpContext context, Exception ex)
    {
      //CaptureException(ex);

      _logger.LogCritical(ex, $"{context.Request.Path.Value} Exception");

      context.Response.ContentType = "application/json";
      context.Response.StatusCode = StatusCodes.Status500InternalServerError;
      await context.Response.WriteAsync(JsonSerializer.Serialize("{\"hello\":\"world\"}"));
    }


    /*
    /// <summary>
    /// Capture APM with Elastic
    /// </summary>
    /// <param name="ex"></param>
    private void CaptureException(Exception ex)
    {
      var transaction = Elastic.Apm.Agent.Tracer.CurrentTransaction;
      if (transaction != null)
        transaction.CaptureException(ex);
    }
    */
  }
}

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SC.UserManagment.Api.Controllers.Error;

/// <summary>
/// 
/// </summary>
[ApiController]
[ApiVersionNeutral]
public class ErrorsController : ControllerBase
{
  /// <summary>
  /// 
  /// </summary>
  /// <returns></returns>
  /// <exception cref="Exception"></exception>
  [HttpGet("Throw")]
  public IActionResult Throw() =>
      throw new Exception("Sample exception.");
  

  /// <summary>
  /// 
  /// </summary>
  /// <param name="hostEnvironment"></param>
  /// <returns></returns>
  [Route("error-development")]
  [ApiExplorerSettings(IgnoreApi = true)]
  public IActionResult HandleErrorDevelopment(
      [FromServices] IHostEnvironment hostEnvironment)
  {
    if (!hostEnvironment.IsDevelopment())
    {
      return NotFound();
    }

    var exceptionHandlerFeature =
        HttpContext.Features.Get<IExceptionHandlerFeature>()!;

    return Problem(
        detail: exceptionHandlerFeature.Error.StackTrace,
        title: exceptionHandlerFeature.Error.Message);
  }

  /// <summary>
  /// 
  /// </summary>
  /// <returns></returns>
  [Route("error")]
  [ApiExplorerSettings(IgnoreApi = true)]
  public IActionResult HandleError() =>
      Problem();

}
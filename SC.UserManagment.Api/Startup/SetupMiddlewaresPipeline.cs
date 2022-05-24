using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SC.UserManagment.Api.Helpers;
using SC.UserManagment.Api.Middlewares;

namespace SC.UserManagment.Api.Startup
{
  /// <summary>
  /// Configure the pipeline before running the app
  /// </summary>
  public static class SetupMiddlewaresPipeline
  {
    /// <summary>
    /// Substitute for Startup.Configure method
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static WebApplication SetupMiddlewares(this WebApplication app)
    {


      // Configure application
      var provider = app.Services.GetService<IApiVersionDescriptionProvider>();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger(c => c.RouteTemplate = "/swagger/{documentname}/swagger.json");
        app.UseSwaggerUI(options =>
        {
          if (provider != null)
          {
            foreach (var description in provider.ApiVersionDescriptions)
            {
              options.RoutePrefix = "swagger";
              options.SwaggerEndpoint(SwaggerHelper.UrlEndpoint(description.GroupName), description.GroupName.ToUpperInvariant());
            }
          }
        });
        app.UseExceptionHandler($"/error-development");
      }
      else
      {
        app.UseExceptionHandler($"/error");
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      //app.UseStaticFiles();
      // app.UseCookiePolicy();

      app.UseRouting();
      // app.UseRequestLocalization();
      // app.UseCors();

      app.UseAuthentication();
      app.UseAuthorization();
      // app.UseSession();
      // app.UseResponseCompression();
      // app.UseResponseCaching();

      app.UseErrorHandlingMiddlewareWhenNot("/api/health");

      app.MapControllers();
      app.MapHealthChecks("api/health");


      return app;
    }
  }
}

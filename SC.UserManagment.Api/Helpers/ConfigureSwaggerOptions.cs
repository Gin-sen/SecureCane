using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SC.UserManagment.Api.Helpers
{
  /// <summary>
  /// Configures the Swagger generation options.
  /// </summary>
  /// <remarks>This allows API versioning to define a Swagger document per API version after the
  /// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
  public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
  {

    readonly IApiVersionDescriptionProvider provider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
    /// </summary>
    /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

    /// <summary>
    /// Configuration
    /// </summary>
    /// <param name="options"></param>
    public void Configure(SwaggerGenOptions options)
    {
      foreach (var description in provider.ApiVersionDescriptions)
      {
        options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
      }
      var basePath = AppContext.BaseDirectory;
      var xmlPath = Path.Combine(basePath, "Api.xml");
      basePath = basePath.Replace("Api", "Application");
      var applicationXml = Path.Combine(basePath, "Application.xml");

      if (File.Exists(xmlPath))
        options.IncludeXmlComments(xmlPath);
      if (File.Exists(applicationXml))
        options.IncludeXmlComments(applicationXml);
      options.DocInclusionPredicate((version, desc) =>
      {
        return desc.GetApiVersion()?.MajorVersion?.ToString() == version;
      });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    {
      var info = new OpenApiInfo()
      {
        Title = "SecureCane User API",
        Version = description.ApiVersion.ToString(),
        Description = "Service de gestion des utilisateurs",
        Contact = new OpenApiContact() { Name = "Team SecureCane" },
      };
      if (description.IsDeprecated)
      {
        info.Description += " This API version has been deprecated.";
      }
      return info;
    }
  }
}

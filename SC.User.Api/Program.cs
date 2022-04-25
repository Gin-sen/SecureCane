using Elastic.Apm.SerilogEnricher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using SC.User.Api.Helpers;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using static System.Net.Mime.MediaTypeNames;


// Build application
var builder = WebApplication.CreateBuilder(args);

#region SerilogAPM
// Logging
// remove default logging providers
builder.Logging.ClearProviders();

// Serilog configuration        
var logger = new LoggerConfiguration()
#if !DEBUG
    // for Elastic APM (see : https://www.elastic.co/guide/en/apm/agent/dotnet/master/serilog.html)
    .Enrich.WithElasticApmCorrelationInfo()
    .WriteTo.Console(outputTemplate: "[{ElasticApmTraceId} {ElasticApmTransactionId} {Message:lj} {NewLine}{Exception}")*/
#else
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}")
#endif
    .CreateLogger();
// Register Serilog
builder.Logging.AddSerilog(logger);
#endregion SerilogAPM

// Add services to the container.
builder.Services.AddHealthChecks();
builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
              options.InvalidModelStateResponseFactory = context =>
                  new BadRequestObjectResult(context.ModelState)
                  {
                    ContentTypes =
                      {
                            // using static System.Net.Mime.MediaTypeNames;
                            Application.Json
                      }
                  };
            });

#region Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApiVersioning(options =>
  {
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
  });
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddVersionedApiExplorer(options =>
{
  options.GroupNameFormat = "VVV";
  options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion Swagger

var app = builder.Build();


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
  app.UseExceptionHandler($"/api/errors/error-development");
}
else
{
  app.UseExceptionHandler($"/api/errors/error");
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

app.MapControllers();
app.MapHealthChecks("api/health");
app.Run();

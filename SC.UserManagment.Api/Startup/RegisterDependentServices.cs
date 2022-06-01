using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SC.Common.CQRS;
using SC.Common.CQRS.Commands;
using SC.Common.CQRS.Queries;
using SC.UserManagment.Api.Helpers;
using SC.UserManagment.Application.Commands.CreateUser;
using SC.UserManagment.Application.Models.V1.User;
using SC.UserManagment.Application.Queries.GetUser;
using SC.UserManagment.Application.Queries.GetUsers;
using SC.UserManagment.Application.Repositories;
using SC.UserManagment.Application.Services;
using SC.UserManagment.AzureTable.Repositories;
using SC.UserManagment.AzureTable.Services;
using SC.UserManagment.AzureTable.Tables;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SC.UserManagment.Api.Startup
{
  /// <summary>
  /// Register your dependencies
  /// </summary>
  public static class RegisterDependentServices
  {
    /// <summary>
    /// Substitute for Startup.ConfigureServices method
    /// Usage : WebApplication.CreateBuilder(args).RegisterServices().Build();
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
      IConfiguration configuration = builder.Configuration;

      // Logger
      RegisterSerilogAPM(builder, "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}");

      // Basics
      builder.Services.AddHealthChecks();
      builder.Services.AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
          ConfigureModelState(options);
        });

      // Tables
      builder.Services.AddSingleton<IUserTable>(s => new UserTable("SecureCaneUsers", configuration["ConnectionStrings:CosmosTableApi"]));

      // Repositories
      builder.Services.AddScoped<IUserRepository, UserRepository>();

      // Services
      builder.Services.AddScoped<IUserService, UserService>();

      // CQRS
      builder.Services.AddCqrs();
      //  Commands
      builder.Services.AddScoped<ICommandHandlerAsync<CreateUserCommand, CreateUserResultModel>, CreateUserCommandHandler>();

      //  Queries
      builder.Services.AddScoped<IQueryHandlerAsync<GetUserQuery, GetUserResultModel>, GetUserQueryHandler>();
      builder.Services.AddScoped<IQueryHandlerAsync<GetUsersQuery, GetUsersResultModel>, GetUsersQueryHandler>();
      
      //  Events

      // Swagger
      RegisterSwaggerOpenAPI(builder);

      return builder;
    }

    /// <summary>
    /// Configure standard API behavior
    /// </summary>
    /// <param name="options"></param>
    private static void ConfigureModelState(ApiBehaviorOptions options)
    {
      options.InvalidModelStateResponseFactory = context =>
        new BadRequestObjectResult(context.ModelState)
        {
          ContentTypes =
            {
              // using static System.Net.Mime.MediaTypeNames;
              System.Net.Mime.MediaTypeNames.Application.Json
            }
        };
    }

    /// <summary>
    /// Add Swagger dependencies
    /// </summary>
    /// <param name="builder"></param>
    private static void RegisterSwaggerOpenAPI(WebApplicationBuilder builder)
    {
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
    }

    /// <summary>
    /// Add Logging Service + Elastic APM
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="template"></param>
    private static void RegisterSerilogAPM(WebApplicationBuilder builder, string template)
    {
      // remove default logging providers
      builder.Logging.ClearProviders();

      var logger = new LoggerConfiguration()
#if !DEBUG
      // for Elastic APM (see : https://www.elastic.co/guide/en/apm/agent/dotnet/master/serilog.html)
      .Enrich.WithElasticApmCorrelationInfo()
      .WriteTo.Console(outputTemplate: "[{ElasticApmTraceId} {ElasticApmTransactionId} {Message:lj} {NewLine}{Exception}")*/
#else
      .WriteTo.Console(outputTemplate: template)
#endif
      .CreateLogger();

      builder.Logging.AddSerilog(logger);
    }
  }
}

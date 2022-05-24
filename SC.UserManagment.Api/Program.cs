using SC.UserManagment.Api.Startup;

// Build application
var app = WebApplication.CreateBuilder(args)
  .RegisterServices()
  .Build();

app.SetupMiddlewares()
  .Run();
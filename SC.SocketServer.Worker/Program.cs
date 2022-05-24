using SC.SocketServer.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
      services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();

using Microsoft.Extensions.DependencyInjection;
using SC.Common.CQRS.Commands;
using SC.Common.CQRS.Events;
using SC.Common.CQRS.Queries;

namespace SC.Common.CQRS
{
  public static class DependencyInjection
  {
    /// <summary>
    /// Add Classes dependencies
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException">services</exception>
    public static IServiceCollection AddCqrs(this IServiceCollection services)
    {
      if (services == null)
        throw new ArgumentNullException(nameof(services));


      services.AddScoped<ICommandSender, CommandSender>();
      services.AddScoped<IQueryProcessor, QueryProcessor>();
      services.AddScoped<IEventPublisher, EventPublisher>();
      services.AddScoped<IDispatcher, Dispatcher>();

      return services;
    }
  }
}

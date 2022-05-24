using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.Common.CQRS.Events
{
  /// <inheritdoc />
  public class EventPublisher : IEventPublisher
  {
    /// <summary>
    /// The service provider
    /// </summary>
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="EventPublisher"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    public EventPublisher(IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
    }

    /// <inheritdoc />
    public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
    {
      if (@event == null)
        throw new ArgumentNullException(nameof(@event));

      var handlers = _serviceProvider.GetServices<IEventHandlerAsync<TEvent>>();

      foreach (var handler in handlers)
        await handler.HandleAsync(@event);
    }

    /// <inheritdoc />
    public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
      if (@event == null)
        throw new ArgumentNullException(nameof(@event));

      var handlers = _serviceProvider.GetServices<IEventHandler<TEvent>>();

      foreach (var handler in handlers)
        handler.Handle(@event);
    }
  }
}

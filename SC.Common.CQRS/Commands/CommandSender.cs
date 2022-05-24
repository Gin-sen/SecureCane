using SC.Common.CQRS.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.Common.CQRS.Commands
{
  /// <inheritdoc />
  public class CommandSender : ICommandSender
  {
    /// <summary>
    /// The service provider
    /// </summary>
    private readonly IServiceProvider _serviceProvider;
    /// <summary>
    /// The event publisher
    /// </summary>
    private readonly IEventPublisher _eventPublisher;


    public CommandSender(IServiceProvider serviceProvider,
        IEventPublisher eventPublisher)
    {
      _serviceProvider = serviceProvider;
      _eventPublisher = eventPublisher;
    }

    /// <inheritdoc />
    public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
    {
      if (command == null)
        throw new ArgumentNullException(nameof(command));

      var handler = _serviceProvider.GetRequiredService<ICommandHandlerAsync<TCommand>>();

      var events = await handler.HandleAsync(command);
      await PublishEventsAsync(events);
    }



    /// <inheritdoc />
    public async Task<TResultID> SendAsync<TCommand, TResultID>(TCommand command) where TCommand : ICommand
    {
      if (command == null)
        throw new ArgumentNullException(nameof(command));

      var handler = _serviceProvider.GetRequiredService<ICommandHandlerAsync<TCommand, TResultID>>();

      var commandResult = await handler.HandleAsync(command);

      await PublishEventsAsync(commandResult.Events);

      return commandResult.Id;
    }

    /// <inheritdoc />
    public void Send<TCommand>(TCommand command) where TCommand : ICommand
    {
      if (command == null)
        throw new ArgumentNullException(nameof(command));

      var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();

      var events = handler.Handle(command);
      PublishEvents(events);
    }

    /// <inheritdoc />
    public TResultID Send<TCommand, TResultID>(TCommand command) where TCommand : ICommand
    {
      if (command == null)
        throw new ArgumentNullException(nameof(command));

      var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResultID>>();

      var commandResult = handler.Handle(command);

      PublishEvents(commandResult.Events);

      return commandResult.Id;
    }


    /// <summary>
    /// Publishes the events.
    /// </summary>
    /// <param name="events">The events.</param>
    private void PublishEvents(IEnumerable<IEvent> events)
    {
      if (events != null)
      {
        foreach (var @event in events)
        {
          _eventPublisher.Publish(@event as dynamic);
        }
      }
    }

    /// <summary>
    /// Publishes the events asynchronously.
    /// </summary>
    /// <param name="events">The events.</param>
    private async Task PublishEventsAsync(IEnumerable<IEvent> events)
    {
      if (events != null)
      {
        foreach (var @event in events)
        {
          await this._eventPublisher.PublishAsync(@event as dynamic);
        }
      }
    }
  }
}

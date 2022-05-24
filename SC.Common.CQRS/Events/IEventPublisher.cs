using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.Common.CQRS.Events
{
  /// <summary>
  /// IEventPublisher
  /// </summary>
  public interface IEventPublisher
  {
    /// <summary>
    /// Asynchronously publishes the specified event.
    /// The event handler must implement EbpCqrs.Events.IEventHandlerAsync&lt;TEvent&gt;.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <param name="event">The event.</param>
    Task PublishAsync<TEvent>(TEvent @event)
        where TEvent : IEvent;

    /// <summary>
    /// Publishes the specified event.
    /// The event handler must implement EbpCqrs.Events.IEventHandler&lt;TEvent&gt;.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <param name="event">The event.</param>
    void Publish<TEvent>(TEvent @event)
        where TEvent : IEvent;
  }
}

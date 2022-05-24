using System;
using System.Collections.Generic;
using System.Text;

namespace SC.Common.CQRS.Events
{
  /// <summary>
  /// IEventHandler
  /// </summary>
  /// <typeparam name="TEvent">The type of the event.</typeparam>
  public interface IEventHandler<in TEvent> where TEvent : IEvent
  {
    /// <summary>
    /// Handles the specified event.
    /// </summary>
    /// <param name="event">The event.</param>
    void Handle(TEvent @event);
  }
}

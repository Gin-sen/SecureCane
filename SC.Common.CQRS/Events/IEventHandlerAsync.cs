using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.Common.CQRS.Events
{
  /// <summary>
  /// IEventHandlerAsync
  /// </summary>
  /// <typeparam name="TEvent">The type of the event.</typeparam>
  public interface IEventHandlerAsync<in TEvent> where TEvent : IEvent
  {
    /// <summary>
    /// Handles the asynchronous.
    /// </summary>
    /// <param name="event">The event.</param>
    /// <returns></returns>
    Task HandleAsync(TEvent @event);
  }
}

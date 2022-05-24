using SC.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SC.Common.CQRS.Commands
{
  /// <summary>
  /// ICommandHandler
  /// </summary>
  /// <typeparam name="TCommand">The type of the command.</typeparam>
  public interface ICommandHandler<in TCommand> where TCommand : ICommand
  {
    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>the events to publish if any (can be null)</returns>
    IEnumerable<IEvent> Handle(TCommand command);
  }

  /// <summary>
  /// ICommandHandler
  /// </summary>
  /// <typeparam name="TCommand">The type of the command.</typeparam>
  public interface ICommandHandler<in TCommand, TResultID> where TCommand : ICommand
  {
    /// <summary>
    /// Handles the specified command.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>
    /// A commandResult that contains an ID and the events to publish if any (can be null)
    /// </returns>
    CommandResult<TResultID> Handle(TCommand command);
  }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.Common.CQRS.Commands
{
  /// <summary>
  /// ICommandSender
  /// </summary>
  public interface ICommandSender
  {
    /// <summary>
    /// Asynchronously sends the specified command.
    /// The command handler must implement Common.Commands.ICommandHandlerAsync&lt;TCommand&gt;.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    Task SendAsync<TCommand>(TCommand command)
        where TCommand : ICommand;

    /// <summary>
    /// Asynchronously sends the specified command with an ID returned.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TResultID">The type of the identifier returned.</typeparam>
    /// <param name="command">The command.</param>
    /// <returns>an ID</returns>
    Task<TResultID> SendAsync<TCommand, TResultID>(TCommand command) where TCommand : ICommand;

    /// <summary>
    /// Sends the specified command.
    /// The command handler must implement Common.Commands.ICommandHandler&lt;TCommand&gt;.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <param name="command">The command.</param>
    void Send<TCommand>(TCommand command)
        where TCommand : ICommand;

    /// <summary>
    /// sends the specified command with an ID returned.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TResultID">The type of the identifier returned.</typeparam>
    /// <param name="command">The command.</param>
    /// <returns>an ID</returns>
    TResultID Send<TCommand, TResultID>(TCommand command)
      where TCommand : ICommand;
  }
}

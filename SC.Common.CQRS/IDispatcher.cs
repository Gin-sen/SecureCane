using SC.Common.CQRS.Commands;
using SC.Common.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.Common.CQRS
{
  /// <summary>
  /// IDispatcher
  /// </summary>
  public interface IDispatcher
  {
    /// <summary>
    /// Asynchronously sends the specified command.
    /// The command handler must implement EbpCqrs.Commands.ICommandHandlerAsync&lt;TCommand&gt;.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    Task SendAsync<TCommand>(TCommand command)
        where TCommand : ICommand;

    /// <summary>
    /// Asynchronously sends the specified command.
    /// The command handler must implement EbpCqrs.Commands.ICommandHandlerAsync&lt;TCommand&gt;.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TResultID">The type of the result identifier.</typeparam>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    Task<TResultID> SendAsync<TCommand, TResultID>(TCommand command)
      where TCommand : ICommand;

    /// <summary>
    /// Asynchronously gets the result.
    /// The query handler must implement EbpCqrs.Queries.IQueryHandlerAsync&lt;TQuery, TResult&gt;.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="query">The query.</param>
    /// <returns>TResult</returns>
    Task<TResult> GetResultAsync<TQuery, TResult>(TQuery query)
        where TQuery : IQuery;

    /// <summary>
    /// Sends the specified command.
    /// The command handler must implement EbpCqrs.Commands.ICommandHandler&lt;TCommand&gt;.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <param name="command">The command.</param>
    void Send<TCommand>(TCommand command)
        where TCommand : ICommand;

    /// <summary>
    ///  sends the specified command.
    /// The command handler must implement EbpCqrs.Commands.ICommandHandlerAsync&lt;TCommand&gt;.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TResultID">The type of the result identifier.</typeparam>
    /// <param name="command">The command.</param>
    /// <returns></returns>
    TResultID Send<TCommand, TResultID>(TCommand command)
      where TCommand : ICommand;

    /// <summary>
    /// Gets the result.
    /// The query handler must implement EbpCqrs.Queries.IQueryHandler&lt;TQuery, TResult&gt;.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="query">The query.</param>
    /// <returns>TResult</returns>
    TResult GetResult<TQuery, TResult>(TQuery query)
        where TQuery : IQuery;
  }
}

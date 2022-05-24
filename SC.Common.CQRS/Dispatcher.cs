using SC.Common.CQRS.Commands;
using SC.Common.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.Common.CQRS
{
  /// <inheritdoc />
  /// <summary>
  /// Dispatcher
  /// </summary>
  /// <seealso cref="T:EbpCqrs.IDispatcher" />
  public class Dispatcher : IDispatcher
  {
    /// <summary>
    /// The command sender
    /// </summary>
    private readonly ICommandSender _commandSender;

    /// <summary>
    /// The query processor
    /// </summary>
    private readonly IQueryProcessor _queryProcessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="Dispatcher"/> class.
    /// </summary>
    /// <param name="commandSender">The command sender.</param>
    /// <param name="queryProcessor">The query processor.</param>
    public Dispatcher(ICommandSender commandSender,
                      IQueryProcessor queryProcessor)
    {
      _commandSender = commandSender;
      _queryProcessor = queryProcessor;
    }

    /// <inheritdoc />
    public Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
    {
      return _commandSender.SendAsync(command);
    }

    public Task<TResultID> SendAsync<TCommand, TResultID>(TCommand command) where TCommand : ICommand
    {
      return _commandSender.SendAsync<TCommand, TResultID>(command);
    }

    /// <inheritdoc />
    public Task<TResult> GetResultAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
    {
      return _queryProcessor.ProcessAsync<TQuery, TResult>(query);
    }

    /// <inheritdoc />
    public void Send<TCommand>(TCommand command) where TCommand : ICommand
    {
      _commandSender.Send(command);
    }

    /// <inheritdoc />
    public TResultID Send<TCommand, TResultID>(TCommand command) where TCommand : ICommand
    {
      return _commandSender.Send<TCommand, TResultID>(command);
    }

    /// <inheritdoc />
    public TResult GetResult<TQuery, TResult>(TQuery query) where TQuery : IQuery
    {
      return _queryProcessor.Process<TQuery, TResult>(query);
    }



  }
}

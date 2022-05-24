using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.Common.CQRS.Queries
{
  /// <summary>
  /// IQueryProcessor
  /// </summary>
  public interface IQueryProcessor
  {
    /// <summary>
    /// Asynchronously gets the result.
    /// The query handler must implement EbpCqrs.Queries.IQueryHandlerAsync&lt;TQuery, TResult&gt;.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="query">The query.</param>
    /// <returns>TResult</returns>
    Task<TResult> ProcessAsync<TQuery, TResult>(TQuery query)
        where TQuery : IQuery;

    /// <summary>
    /// Gets the result.
    /// The query handler must implement EbpCqrs.Queries.IQueryHandler&lt;TQuery, TResult&gt;.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="query">The query.</param>
    /// <returns>TResult</returns>
    TResult Process<TQuery, TResult>(TQuery query)
        where TQuery : IQuery;
  }
}

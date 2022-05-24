using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.Common.CQRS.Queries
{
  /// <summary>
  /// IQueryHandlerAsync Interface to handle asynchronous queries
  /// </summary>
  /// <typeparam name="TQuery">The type of the query.</typeparam>
  /// <typeparam name="TResult">The type of the result.</typeparam>
  public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery
  {
    /// <summary>
    /// Retrieves the asynchronous.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns></returns>
    Task<TResult> RetrieveAsync(TQuery query);
  }
}

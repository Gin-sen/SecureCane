using System;
using System.Collections.Generic;
using System.Text;

namespace SC.Common.CQRS.Queries
{
  /// <summary>
  /// IQueryHandler Interface pour le handler de query
  /// </summary>
  /// <typeparam name="TQuery">The type of the query.</typeparam>
  /// <typeparam name="TResult">The type of the result.</typeparam>
  public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery
  {
    /// <summary>
    /// Retrieves the specified query.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns></returns>
    TResult Retrieve(TQuery query);
  }
}

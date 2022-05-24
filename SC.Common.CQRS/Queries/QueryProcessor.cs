using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.Common.CQRS.Queries
{
  /// <inheritdoc />
  public class QueryProcessor : IQueryProcessor
  {
    /// <summary>
    /// The service provider
    /// </summary>
    private readonly IServiceProvider _serviceProvider;


    /// <summary>
    /// Initializes a new instance of the <see cref="QueryProcessor"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    public QueryProcessor(IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
    }

    /// <inheritdoc />
    public Task<TResult> ProcessAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
    {
      if (query == null)
        throw new ArgumentNullException(nameof(query));

      var handler = _serviceProvider.GetRequiredService<IQueryHandlerAsync<TQuery, TResult>>();

      return handler.RetrieveAsync(query);
    }

    /// <inheritdoc />
    public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery
    {
      if (query == null)
        throw new ArgumentNullException(nameof(query));

      var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();

      return handler.Retrieve(query);
    }
  }
}

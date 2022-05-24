using SC.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SC.Common.CQRS.Commands
{
  /// <summary>
  /// Resultat d'une commande qui doit retourner un ID et des évènement (les evenement sont optionnels)
  /// </summary>
  /// <typeparam name="TID">The type of the identifier.</typeparam>
  public class CommandResult<TID>
  {
    /// <summary>
    /// Gets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public TID Id { get; private set; }
    /// <summary>
    /// Gets the events.
    /// </summary>
    /// <value>
    /// The events.
    /// </value>
    public IEnumerable<IEvent> Events { get; private set; }



    /// <summary>
    /// Initializes a new instance of the <see cref="CommandResult{TID}"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="events">The events.</param>
    public CommandResult(TID id, params IEvent[] events)
    {
      Id = id;
      Events = events;
    }
  }
}

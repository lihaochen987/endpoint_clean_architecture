namespace Clean.Architecture.SharedKernel;

using Interfaces;
using MediatR;

/// <summary>
/// TODO.
/// </summary>
public class DomainEventDispatcher : IDomainEventDispatcher
{
  private readonly IMediator _mediator;

  /// <summary>
  /// Initializes a new instance of the <see cref="DomainEventDispatcher"/> class.
  /// </summary>
  /// <param name="mediator">TODO LATER.</param>
  public DomainEventDispatcher(IMediator mediator)
  {
    _mediator = mediator;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="entitiesWithEvents">TODO LATER.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  public async Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents)
  {
    foreach (var entity in entitiesWithEvents)
    {
      var events = entity.DomainEvents.ToArray();
      entity.ClearDomainEvents();
      foreach (var domainEvent in events)
      {
        await _mediator.Publish(domainEvent).ConfigureAwait(false);
      }
    }
  }
}

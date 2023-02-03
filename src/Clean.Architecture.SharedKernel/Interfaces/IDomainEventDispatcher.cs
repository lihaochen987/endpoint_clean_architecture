namespace Clean.Architecture.SharedKernel.Interfaces;

/// <summary>
/// TODO.
/// </summary>
public interface IDomainEventDispatcher
{
  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="entitiesWithEvents">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents);
}

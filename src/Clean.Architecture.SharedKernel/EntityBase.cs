namespace Clean.Architecture.SharedKernel;

using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// The base class for an Entity object - used in different bounded contexts in an actual project.
/// This can be modified to EntityBase[TId] to support multiple key types (e.g. Guid).
/// </summary>
public abstract class EntityBase
{
  /// <summary>
  /// The list of Domain Events for the entity.
  /// </summary>
  private readonly List<DomainEventBase> _domainEvents = new ();

  /// <summary>
  /// Gets or sets the Id of the entity object.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Gets the Domain Events.
  /// </summary>
  [NotMapped]
  public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

  /// <summary>
  /// Clears the Domain Events.
  /// </summary>
  internal void ClearDomainEvents() => _domainEvents.Clear();

  /// <summary>
  /// Registers a Domain Event to the entity object.
  /// </summary>
  /// <param name="domainEvent">The domain event.</param>
  protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
}

namespace Clean.Architecture.SharedKernel;

using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// TODO.
/// This can be modified to EntityBase[TId] to support multiple key types (e.g. Guid).
/// </summary>
public abstract class EntityBase
{
  /// <summary>
  /// TODO.
  /// </summary>
  private List<DomainEventBase> _domainEvents = new ();

  /// <summary>
  /// Gets or sets the .
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Gets the Domain Events.
  /// </summary>
  [NotMapped]
  public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

  /// <summary>
  /// TODO.
  /// </summary>
  internal void ClearDomainEvents() => _domainEvents.Clear();

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="domainEvent">TODO LATER.</param>
  protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
}

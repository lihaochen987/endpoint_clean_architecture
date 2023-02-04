namespace Clean.Architecture.SharedKernel;

using MediatR;

/// <summary>
/// The base class for a Domain Event - used in different bounded contexts in an actual project.
/// </summary>
public abstract class DomainEventBase : INotification
{
  /// <summary>
  /// Gets or sets the Date the event occurred.
  /// </summary>
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}

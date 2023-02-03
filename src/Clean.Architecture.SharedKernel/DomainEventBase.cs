namespace Clean.Architecture.SharedKernel;

using MediatR;

/// <summary>
/// An event that relates to the business requirements of our domain.
/// </summary>
public abstract class DomainEventBase : INotification
{
  /// <summary>
  /// Gets or sets the Date the event occurred.
  /// </summary>
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}

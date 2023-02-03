namespace Clean.Architecture.Core.ContributorAggregate.Events;

using SharedKernel;

/// <summary>
/// An event where a Contributor is deleted.
/// </summary>
public class ContributorDeletedEvent : DomainEventBase
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ContributorDeletedEvent"/> class.
  /// </summary>
  /// <param name="contributorId">The Id of the Contributor.</param>
  public ContributorDeletedEvent(int contributorId)
  {
    ContributorId = contributorId;
  }

  /// <summary>
  /// Gets or sets the Id of the Contributor that was deleted.
  /// </summary>
  public int ContributorId { get; set; }
}

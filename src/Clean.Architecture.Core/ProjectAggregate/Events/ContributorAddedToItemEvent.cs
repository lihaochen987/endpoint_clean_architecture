namespace Clean.Architecture.Core.ProjectAggregate.Events;

using SharedKernel;

/// <summary>
/// TODO.
/// </summary>
public class ContributorAddedToItemEvent : DomainEventBase
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ContributorAddedToItemEvent"/> class.
  /// </summary>
  /// <param name="item">TODO.</param>
  /// <param name="contributorId">TODO later.</param>
  public ContributorAddedToItemEvent(ToDoItem item, int contributorId)
  {
    Item = item;
    ContributorId = contributorId;
  }

  private int ContributorId { get; set; }

  private ToDoItem Item { get; set; }
}

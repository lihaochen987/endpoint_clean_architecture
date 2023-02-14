namespace Clean.Architecture.Core.ProjectAggregate.Events;

using SharedKernel;

/// <summary>
/// The event that a Contributor has been added to an item.
/// </summary>
public class ContributorAddedToItemEvent : DomainEventBase
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ContributorAddedToItemEvent"/> class.
  /// </summary>
  /// <param name="item">The item object being added to the contributor.</param>
  /// <param name="contributorId">The id of the contributor.</param>
  public ContributorAddedToItemEvent(ToDoItem item, int contributorId)
  {
    Item = item;
    ContributorId = contributorId;
  }

  private int ContributorId { get; }

  private ToDoItem Item { get; }
}

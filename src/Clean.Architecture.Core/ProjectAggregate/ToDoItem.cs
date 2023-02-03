namespace Clean.Architecture.Core.ProjectAggregate;

using Ardalis.GuardClauses;
using Events;
using SharedKernel;

/// <summary>
/// TODO.
/// </summary>
public class ToDoItem : EntityBase
{
  /// <summary>
  /// Gets or sets the Title of the ToDoItem.
  /// </summary>
  public string Title { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the Description of the ToDoItem.
  /// </summary>
  public string Description { get; set; } = string.Empty;

  /// <summary>
  /// Gets the ContributorId of the ToDoItem.
  /// </summary>
  public int? ContributorId { get; private set; }

  /// <summary>
  /// Gets a value indicating whether the ToDoItem is done.
  /// </summary>
  public bool IsDone { get; private set; }

  /// <summary>
  /// TODO.
  /// </summary>
  public void MarkComplete()
  {
    if (!IsDone)
    {
      IsDone = true;

      RegisterDomainEvent(new ToDoItemCompletedEvent(this));
    }
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="contributorId">TODO later.</param>
  public void AddContributor(int contributorId)
  {
    Guard.Against.Null(contributorId, nameof(contributorId));
    ContributorId = contributorId;

    var contributorAddedToItem = new ContributorAddedToItemEvent(this, contributorId);
    this.RegisterDomainEvent(contributorAddedToItem);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  public void RemoveContributor()
  {
    ContributorId = null;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>TODO later.</returns>
  public override string ToString()
  {
    string status = IsDone ? "Done!" : "Not done.";
    return $"{Id}: Status: {status} - {Title} - {Description}";
  }
}

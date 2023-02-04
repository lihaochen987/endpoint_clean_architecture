namespace Clean.Architecture.Core.ProjectAggregate;

using Ardalis.GuardClauses;
using Events;
using SharedKernel;

/// <summary>
/// The ToDoItem entity class.
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
  /// Marks the status of the ToDoItem as complete.
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
  /// Adds a Contributor to the to-do item.
  /// </summary>
  /// <param name="contributorId">The Id of the Contributor.</param>
  public void AddContributor(int contributorId)
  {
    Guard.Against.Null(contributorId, nameof(contributorId));
    ContributorId = contributorId;

    var contributorAddedToItem = new ContributorAddedToItemEvent(this, contributorId);
    this.RegisterDomainEvent(contributorAddedToItem);
  }

  /// <summary>
  /// Removes a Contributor from the ToDoItem.
  /// </summary>
  public void RemoveContributor()
  {
    ContributorId = null;
  }

  /// <summary>
  /// Returns the string message of the ToDoItem.
  /// </summary>
  /// <returns>The string message.</returns>
  public override string ToString()
  {
    string status = IsDone ? "Done!" : "Not done.";
    return $"{Id}: Status: {status} - {Title} - {Description}";
  }
}

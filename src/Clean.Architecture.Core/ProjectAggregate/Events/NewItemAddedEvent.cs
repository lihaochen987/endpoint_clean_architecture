namespace Clean.Architecture.Core.ProjectAggregate.Events;

using SharedKernel;

/// <summary>
/// TODO.
/// </summary>
public class NewItemAddedEvent : DomainEventBase
{
  /// <summary>
  /// Initializes a new instance of the <see cref="NewItemAddedEvent"/> class.
  /// </summary>
  /// <param name="project"> TODO.</param>
  /// <param name="newItem"> TODO later.</param>
  public NewItemAddedEvent(
    Project project,
    ToDoItem newItem)
  {
    Project = project;
    NewItem = newItem;
  }

  /// <summary>
  /// Gets or sets the NewItem.
  /// </summary>
  public ToDoItem NewItem { get; set; }

  /// <summary>
  /// Gets or sets the Project.
  /// </summary>
  public Project Project { get; set; }
}

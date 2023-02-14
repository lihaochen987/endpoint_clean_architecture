namespace Clean.Architecture.Core.ProjectAggregate.Events;

using SharedKernel;

/// <summary>
/// The event that a new item has been added to a project.
/// </summary>
public class NewItemAddedEvent : DomainEventBase
{
  /// <summary>
  /// Initializes a new instance of the <see cref="NewItemAddedEvent"/> class.
  /// </summary>
  /// <param name="project"> The project being added to.</param>
  /// <param name="newItem"> The item being added to the project.</param>
  public NewItemAddedEvent(
    Project project,
    ToDoItem newItem)
  {
    Project = project;
    NewItem = newItem;
  }

  /// <summary>
  /// Gets the NewItem.
  /// </summary>
  private ToDoItem NewItem { get; }

  /// <summary>
  /// Gets the Project.
  /// </summary>
  private Project Project { get; }
}

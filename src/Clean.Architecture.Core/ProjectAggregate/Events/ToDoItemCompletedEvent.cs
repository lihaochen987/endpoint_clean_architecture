namespace Clean.Architecture.Core.ProjectAggregate.Events;

using SharedKernel;

/// <summary>
/// The event that a to-do item has been completed.
/// </summary>
public class ToDoItemCompletedEvent : DomainEventBase
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ToDoItemCompletedEvent"/> class.
  /// </summary>
  /// <param name="completedItem"> TODO later.</param>
  public ToDoItemCompletedEvent(ToDoItem completedItem)
  {
    CompletedItem = completedItem;
  }

  /// <summary>
  /// Gets or sets the CompletedItem.
  /// </summary>
  public ToDoItem CompletedItem { get; set; }
}

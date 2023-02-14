namespace Clean.Architecture.Core.ProjectAggregate;

using Ardalis.GuardClauses;
using Events;
using SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

/// <summary>
/// The Project Domain Model Object.
/// </summary>
public class Project : EntityBase, IAggregateRoot
{
  /// <summary>
  /// The list of to-do items associated with the Project.
  /// </summary>
  private readonly List<ToDoItem> _items = new ();

  /// <summary>
  /// Initializes a new instance of the <see cref="Project"/> class.
  /// </summary>
  /// <param name="name">The name of the project.</param>
  /// <param name="priority">The priority status of the project.</param>
  public Project(string name, PriorityStatus priority)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    Priority = priority;
  }

  /// <summary>
  /// Gets the Name of the Project.
  /// </summary>
  public string Name { get; private set; }

  /// <summary>
  /// Gets the items of the project.
  /// </summary>
  public IEnumerable<ToDoItem> Items => _items.AsReadOnly();

  /// <summary>
  /// Gets the status of the project.
  /// </summary>
  public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

  /// <summary>
  /// Gets the Priority of the project.
  /// </summary>
  public PriorityStatus Priority { get; }

  /// <summary>
  /// Adds a to-do item to the project.
  /// </summary>
  /// <param name="newItem">The to-do item added to the project.</param>
  public void AddItem(ToDoItem newItem)
  {
    Guard.Against.Null(newItem, nameof(newItem));
    _items.Add(newItem);

    var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
    this.RegisterDomainEvent(newItemAddedEvent);
  }

  /// <summary>
  /// Updates the name of the existing project.
  /// </summary>
  /// <param name="newName">The new name of the project.</param>
  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}

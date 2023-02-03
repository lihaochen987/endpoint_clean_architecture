namespace Clean.Architecture.Core.ProjectAggregate;

using Ardalis.GuardClauses;
using Events;
using SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

/// <summary>
/// TODO.
/// </summary>
public class Project : EntityBase, IAggregateRoot
{
  /// <summary>
  /// TODO.
  /// </summary>
  private List<ToDoItem> _items = new List<ToDoItem>();

  /// <summary>
  /// Initializes a new instance of the <see cref="Project"/> class.
  /// </summary>
  /// <param name="name">TODO.</param>
  /// <param name="priority">TODO later.</param>
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
  /// TODO.
  /// </summary>
  /// <param name="newItem">TODO later.</param>
  public void AddItem(ToDoItem newItem)
  {
    Guard.Against.Null(newItem, nameof(newItem));
    _items.Add(newItem);

    var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
    this.RegisterDomainEvent(newItemAddedEvent);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="newName">TODO later.</param>
  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}

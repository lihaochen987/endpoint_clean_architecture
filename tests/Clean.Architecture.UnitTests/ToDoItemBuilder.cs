namespace Clean.Architecture.UnitTests;

using Clean.Architecture.Core.ProjectAggregate;

/// <summary>
/// The builder responsible for instantiating a to-do item object.
/// </summary>
public class ToDoItemBuilder
{
  private ToDoItem _todo = new ToDoItem();

  /// <summary>
  /// Instantiates a to-do item object.
  /// </summary>
  /// <param name="id">The Id of the to-do item object.</param>
  /// <returns>The to-do item builder object.</returns>
  public ToDoItemBuilder Id(int id)
  {
    _todo.Id = id;
    return this;
  }

  /// <summary>
  /// Sets the title of the to-do item object.
  /// </summary>
  /// <param name="title">The Title of the to-do item object.</param>
  /// <returns>The to-do item builder object.</returns>
  public ToDoItemBuilder Title(string title)
  {
    _todo.Title = title;
    return this;
  }

  /// <summary>
  /// Sets the description of the to-do item object.
  /// </summary>
  /// <param name="description">The Description of the to-do item object.</param>
  /// <returns>The to-do item builder object.</returns>
  public ToDoItemBuilder Description(string description)
  {
    _todo.Description = description;
    return this;
  }

  /// <summary>
  /// Sets the default values of the to-do item object.
  /// </summary>
  /// <returns>The to-do item builder object.</returns>
  public ToDoItemBuilder WithDefaultValues()
  {
    _todo = new ToDoItem() { Id = 1, Title = "Test Item", Description = "Test Description" };

    return this;
  }

  /// <summary>
  /// Builds the to-do item object.
  /// </summary>
  /// <returns>The to-do item object.</returns>
  public ToDoItem Build() => _todo;
}

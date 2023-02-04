namespace Clean.Architecture.UnitTests;

using Clean.Architecture.Core.ProjectAggregate;

/// <summary>
/// TODO.
/// Learn more about test builders:
/// https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data.
/// </summary>
public class ToDoItemBuilder
{
  private ToDoItem _todo = new ToDoItem();

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="id">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  public ToDoItemBuilder Id(int id)
  {
    _todo.Id = id;
    return this;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="title">TODO LATER1.</param>
  /// <returns>TODO LATER2.</returns>
  public ToDoItemBuilder Title(string title)
  {
    _todo.Title = title;
    return this;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="description">TODO LATER1.</param>
  /// <returns>TODO LATER2.</returns>
  public ToDoItemBuilder Description(string description)
  {
    _todo.Description = description;
    return this;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>TODO LATER1.</returns>
  public ToDoItemBuilder WithDefaultValues()
  {
    _todo = new ToDoItem() { Id = 1, Title = "Test Item", Description = "Test Description" };

    return this;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>TODO LATER1.</returns>
  public ToDoItem Build() => _todo;
}

namespace Clean.Architecture.UnitTests.Builders;

using Clean.Architecture.Core.ProjectAggregate;

/// <summary>
/// The builder responsible for instantiating a Project object.
/// </summary>
public class ProjectBuilder
{
  private readonly Project _project = new ("TestProject", PriorityStatus.Critical);

  /// <summary>
  /// Sets the Id of the ProjectBuilder.
  /// </summary>
  /// <param name="id">The id.</param>
  /// <returns>The ProjectBuilder.</returns>
  public ProjectBuilder Id(int id)
  {
    _project.Id = id;
    return this;
  }

  /// <summary>
  /// Sets the Name of the ProjectBuilder.
  /// </summary>
  /// <param name="name">The name.</param>
  /// <returns>The ProjectBuilder.</returns>
  public ProjectBuilder Name(string name)
  {
    _project.UpdateName(name);
    return this;
  }

  /// <summary>
  /// Initialises the default values of the ProjectBuilder.
  /// </summary>
  /// <returns>The ProjectBuilder.</returns>
  public ProjectBuilder WithDefaultValues()
  {
    return this;
  }

  /// <summary>
  /// Adds items to the ProjectBuilder.
  /// </summary>
  /// <param name="items">The to-do items to be added.</param>
  /// <returns>The ProjectBuilder.</returns>
  public ProjectBuilder Items(IList<ToDoItem> items)
  {
    foreach (ToDoItem toDoItem in items)
    {
      _project.AddItem(toDoItem);
    }

    return this;
  }

  /// <summary>
  /// Builds the Project object.
  /// </summary>
  /// <returns>The Project object.</returns>
  public Project Build() => _project;
}

namespace Clean.Architecture.Web.ProjectEndpoints;

/// <summary>
/// The Response contract from the Project GetById endpoint.
/// </summary>
public class GetProjectByIdResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="GetProjectByIdResponse"/> class.
  /// </summary>
  /// <param name="id">The id of the project.</param>
  /// <param name="name">The name of the project.</param>
  /// <param name="items">The to-do items associated with the project.</param>
  public GetProjectByIdResponse(int id, string name, List<ToDoItemRecord> items)
  {
    Id = id;
    Name = name;
    Items = items;
  }

  /// <summary>
  /// Gets the Id of the project.
  /// </summary>
  public int Id { get; }

  /// <summary>
  /// Gets the Name of the project.
  /// </summary>
  public string Name { get; }

  /// <summary>
  /// Gets to-do items associated with the project.
  /// </summary>
  public List<ToDoItemRecord> Items { get; }
}

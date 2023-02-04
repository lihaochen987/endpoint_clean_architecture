namespace Clean.Architecture.Web.ProjectEndpoints;

/// <summary>
/// TODO.
/// </summary>
public class GetProjectByIdResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="GetProjectByIdResponse"/> class.
  /// </summary>
  /// <param name="id">TODO LATER.</param>
  /// <param name="name">TODO LATER2.</param>
  /// <param name="items">TODO LATER3.</param>
  public GetProjectByIdResponse(int id, string name, List<ToDoItemRecord> items)
  {
    Id = id;
    Name = name;
    Items = items;
  }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public List<ToDoItemRecord> Items { get; set; }
}

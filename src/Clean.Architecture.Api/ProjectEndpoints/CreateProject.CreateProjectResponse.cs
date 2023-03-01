namespace Clean.Architecture.Web.ProjectEndpoints;

/// <summary>
/// The Response contract from the Project Create endpoint.
/// </summary>
public class CreateProjectResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="CreateProjectResponse"/> class.
  /// </summary>
  /// <param name="id">The Id of the project.</param>
  /// <param name="name">The Name of the project.</param>
  public CreateProjectResponse(int id, string name)
  {
    Id = id;
    Name = name;
  }

  /// <summary>
  /// Gets the Id of the project.
  /// </summary>
  public int Id { get; }

  /// <summary>
  /// Gets the Name of the project.
  /// </summary>
  public string Name { get; }
}

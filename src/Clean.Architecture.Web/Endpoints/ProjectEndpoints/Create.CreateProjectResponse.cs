namespace Clean.Architecture.Web.Endpoints.ProjectEndpoints;

/// <summary>
/// TODO.
/// </summary>
public class CreateProjectResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="CreateProjectResponse"/> class.
  /// </summary>
  /// <param name="id">TODO LATER.</param>
  /// <param name="name">TODO LATER2.</param>
  public CreateProjectResponse(int id, string name)
  {
    Id = id;
    Name = name;
  }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  private int Id { get; set; }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  private string Name { get; set; }
}

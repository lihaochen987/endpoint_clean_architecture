namespace Clean.Architecture.Web.Endpoints.ProjectEndpoints;

/// <summary>
/// TODO.
/// </summary>
public class UpdateProjectResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="UpdateProjectResponse"/> class.
  /// </summary>
  /// <param name="project">TODO LATER.</param>
  public UpdateProjectResponse(ProjectRecord project)
  {
    Project = project;
  }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  private ProjectRecord Project { get; set; }
}

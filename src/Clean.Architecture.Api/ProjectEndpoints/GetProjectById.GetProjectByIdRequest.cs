namespace Clean.Architecture.Web.ProjectEndpoints;

/// <summary>
/// The Request Contract to the Project GetById endpoint.
/// </summary>
public class GetProjectByIdRequest
{
  /// <summary>
  /// Gets or sets id of the project.
  /// </summary>
  public int ProjectId { get; set; }
}

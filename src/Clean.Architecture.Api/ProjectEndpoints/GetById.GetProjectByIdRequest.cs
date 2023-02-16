namespace Clean.Architecture.Web.ProjectEndpoints;

/// <summary>
/// The Request Contract to the Project GetById endpoint.
/// </summary>
public class GetProjectByIdRequest
{
  /// <summary>
  /// The route of the endpoint.
  /// </summary>
  public const string Route = "/Projects/{ProjectId:int}";

  /// <summary>
  /// Gets or sets id of the project.
  /// </summary>
  public int ProjectId { get; set; }

  /// <summary>
  /// Builds the route of the project for testing purposes.
  /// </summary>
  /// <param name="projectId">The id of the project.</param>
  /// <returns>The build route associated with the contract request.</returns>
  public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());
}

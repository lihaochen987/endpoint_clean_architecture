namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// The Request DTO to the Contributor GetProjectById endpoint.
/// </summary>
public class GetContributorByIdRequest
{
  /// <summary>
  /// The route of the endpoint.
  /// </summary>
  public const string Route = "/Contributors/{ContributorId:int}";

  /// <summary>
  /// Gets or sets the route of the Contributor.
  /// </summary>
  public int ContributorId { get; set; }

  /// <summary>
  /// Builds the route for testing purposes.
  /// </summary>
  /// <param name="contributorId">The Id of the contributor object.</param>
  /// <returns>A Build Route.</returns>
  public static string BuildRoute(int contributorId) => Route.Replace("{ContributorId:int}", contributorId.ToString());
}

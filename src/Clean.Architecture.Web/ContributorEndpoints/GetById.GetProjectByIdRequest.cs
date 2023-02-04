namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

/// <summary>
/// TODO.
/// </summary>
public class GetContributorByIdRequest
{
  /// <summary>
  /// TODO.
  /// </summary>
  public const string Route = "/Contributors/{ContributorId:int}";

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public int ContributorId { get; set; }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="contributorId">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  public static string BuildRoute(int contributorId) => Route.Replace("{ContributorId:int}", contributorId.ToString());
}

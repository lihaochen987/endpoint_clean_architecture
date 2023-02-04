namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// The Response DTO from the Contributor List endpoint.
/// </summary>
public class ContributorListResponse
{
  /// <summary>
  /// Gets the Contributors.
  /// </summary>
  public List<ContributorRecord> Contributors { get; init; } = new ();
}

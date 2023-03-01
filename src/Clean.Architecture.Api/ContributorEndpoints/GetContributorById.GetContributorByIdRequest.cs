namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// The Request DTO to the Contributor GetProjectById endpoint.
/// </summary>
public class GetContributorByIdRequest
{
  /// <summary>
  /// Gets or sets the route of the Contributor.
  /// </summary>
  public int ContributorId { get; set; }
}

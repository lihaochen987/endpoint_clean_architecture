namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// The Response DTO from the Contributor Update endpoint.
/// </summary>
public class UpdateContributorResponse
{
  /// <summary>
  /// Gets or sets the Contributor.
  /// </summary>
  public ContributorRecord? Contributor { get; set; }
}

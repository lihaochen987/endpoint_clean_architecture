namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// The Request DTO to the Contributor Delete endpoint.
/// </summary>
public class DeleteContributorRequest
{
  /// <summary>
  /// Gets or sets the Id of the Contributor.
  /// </summary>
  public int ContributorId { get; set; }
}

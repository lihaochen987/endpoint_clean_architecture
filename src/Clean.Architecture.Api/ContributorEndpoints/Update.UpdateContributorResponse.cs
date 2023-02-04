namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// The Response DTO from the Contributor Update endpoint.
/// </summary>
public class UpdateContributorResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="UpdateContributorResponse"/> class.
  /// </summary>
  /// <param name="contributor">The contributor object.</param>
  public UpdateContributorResponse(ContributorRecord contributor)
  {
    Contributor = contributor;
  }

  /// <summary>
  /// Gets or sets the Contributor.
  /// </summary>
  private ContributorRecord Contributor { get; set; }
}

namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// TODO.
/// </summary>
public class UpdateContributorResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="UpdateContributorResponse"/> class.
  /// </summary>
  /// <param name="contributor">TODO LATER.</param>
  public UpdateContributorResponse(ContributorRecord contributor)
  {
    Contributor = contributor;
  }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  private ContributorRecord Contributor { get; set; }
}

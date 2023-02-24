namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// The Response contract from the Contributor Create endpoint.
/// </summary>
public class CreateContributorResponse
{
  /// <summary>
  /// Gets or sets id of the contributor.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Gets or sets name of the contributor.
  /// </summary>
  public string? Name { get; set; }
}

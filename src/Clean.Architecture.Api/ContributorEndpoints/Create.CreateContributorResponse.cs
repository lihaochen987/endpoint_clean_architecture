namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// The Response DTO from the Contributor Create endpoint.
/// </summary>
public class CreateContributorResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="CreateContributorResponse"/> class.
  /// </summary>
  /// <param name="id">The Id of the returned Contributor.</param>
  /// <param name="name">The Name of the returned Contributor.</param>
  public CreateContributorResponse(int id, string name)
  {
    Id = id;
    Name = name;
  }

  /// <summary>
  /// Gets or sets Id of the contributor.
  /// </summary>
  private int Id { get; set; }

  /// <summary>
  /// Gets or sets Name of the contributor.
  /// </summary>
  private string Name { get; set; }
}

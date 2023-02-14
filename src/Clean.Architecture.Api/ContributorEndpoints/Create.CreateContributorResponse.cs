namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// The Response contract from the Contributor Create endpoint.
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
  /// Gets id of the contributor.
  /// </summary>
  private int Id { get; }

  /// <summary>
  /// Gets name of the contributor.
  /// </summary>
  private string Name { get; }
}

namespace Clean.Architecture.Web.ContributorEndpoints;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// The Request DTO to the Contributor Create endpoint.
/// </summary>
public class CreateContributorRequest
{
  /// <summary>
  /// The route of the endpoint.
  /// </summary>
  public const string Route = "/Contributors";

  /// <summary>
  /// Gets or sets the Name of the Contributor.
  /// </summary>
  [Required]
  public string? Name { get; set; }
}

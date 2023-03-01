namespace Clean.Architecture.Web.ContributorEndpoints;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// The Request Contract to the Contributor Create endpoint.
/// </summary>
public class CreateContributorRequest
{
  /// <summary>
  /// Gets or sets the Name of the Contributor.
  /// </summary>
  [Required]
  public string? Name { get; set; }
}

namespace Clean.Architecture.Web.ContributorEndpoints;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// The Request DTO to the Contributor Update endpoint.
/// </summary>
public class UpdateContributorRequest
{
  /// <summary>
  /// Gets or sets the Id of the Contributor.
  /// </summary>
  [Required]
  public int Id { get; set; }

  /// <summary>
  /// Gets or sets the Name of the Contributor.
  /// </summary>
  [Required]
  public string? Name { get; set; }
}

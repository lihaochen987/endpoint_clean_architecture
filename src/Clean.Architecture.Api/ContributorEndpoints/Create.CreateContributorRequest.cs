namespace Clean.Architecture.Web.ContributorEndpoints;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// TODO.
/// </summary>
public class CreateContributorRequest
{
  /// <summary>
  /// TODO.
  /// </summary>
  public const string Route = "/Contributors";

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  [Required]
  public string? Name { get; set; }
}

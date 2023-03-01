namespace Clean.Architecture.Web.ProjectEndpoints;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// TODO.
/// </summary>
public class UpdateProjectRequest
{
  /// <summary>
  /// TODO.
  /// </summary>
  public const string Route = "/Projects";

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  [Required]
  public int Id { get; set; }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  [Required]
  public string? Name { get; set; }
}

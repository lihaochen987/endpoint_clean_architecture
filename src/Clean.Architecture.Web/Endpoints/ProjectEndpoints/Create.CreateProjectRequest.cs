namespace Clean.Architecture.Web.Endpoints.ProjectEndpoints;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// TODO.
/// </summary>
public class CreateProjectRequest
{
  /// <summary>
  /// TODO.
  /// </summary>
  public const string Route = "/Projects";

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  [Required]
  public string? Name { get; set; }
}

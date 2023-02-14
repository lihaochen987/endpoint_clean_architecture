namespace Clean.Architecture.Web.ProjectEndpoints;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// The Request Contract to the Project Create endpoint.
/// </summary>
public class CreateProjectRequest
{
  /// <summary>
  /// The route of the endpoint.
  /// </summary>
  public const string Route = "/Projects";

  /// <summary>
  /// Gets or sets the name of the Project.
  /// </summary>
  [Required]
  public string? Name { get; set; }
}

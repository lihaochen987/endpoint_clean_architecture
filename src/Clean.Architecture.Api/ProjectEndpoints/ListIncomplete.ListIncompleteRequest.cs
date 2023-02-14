namespace Clean.Architecture.Web.ProjectEndpoints;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// TODO.
/// </summary>
public class ListIncompleteRequest
{
  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  [FromRoute]
  public int ProjectId { get; set; }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  [FromQuery]
  public string? SearchString { get; set; }
}

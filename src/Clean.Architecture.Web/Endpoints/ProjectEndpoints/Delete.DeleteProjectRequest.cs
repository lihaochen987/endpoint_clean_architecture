﻿namespace Clean.Architecture.Web.Endpoints.ProjectEndpoints;

/// <summary>
/// TODO.
/// </summary>
public class DeleteProjectRequest
{
  /// <summary>
  /// TODO.
  /// </summary>
  public const string Route = "/Projects/{ProjectId:int}";

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public int ProjectId { get; set; }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="projectId">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());
}

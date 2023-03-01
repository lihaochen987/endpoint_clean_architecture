namespace Clean.Architecture.Web.ProjectEndpoints;

/// <summary>
/// The shared response class of Project endpoints.
/// </summary>
/// <param name="projectId">The Id of the project.</param>
/// <param name="projectName">The Name of the project.</param>
public record ProjectRecord(int projectId, string projectName);

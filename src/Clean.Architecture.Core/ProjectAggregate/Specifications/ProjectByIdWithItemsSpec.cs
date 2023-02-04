namespace Clean.Architecture.Core.ProjectAggregate.Specifications;

using Ardalis.Specification;
using ProjectAggregate;

/// <summary>
/// The database query specification which gets a Project by Id with to-do items.
/// </summary>
public sealed class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ProjectByIdWithItemsSpec"/> class.
  /// </summary>
  /// <param name="projectId">The Id of the project.</param>
  public ProjectByIdWithItemsSpec(int projectId)
  {
    Query
      .Where(project => project.Id == projectId)
      .Include(project => project.Items);
  }
}

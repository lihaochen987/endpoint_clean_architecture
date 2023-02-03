namespace Clean.Architecture.Core.ProjectAggregate.Specifications;

using Ardalis.Specification;
using ProjectAggregate;

/// <summary>
/// TODO.
/// </summary>
public class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ProjectByIdWithItemsSpec"/> class.
  /// </summary>
  /// <param name="projectId">TODO.</param>
  public ProjectByIdWithItemsSpec(int projectId)
  {
    Query
      .Where(project => project.Id == projectId)
      .Include(project => project.Items);
  }
}

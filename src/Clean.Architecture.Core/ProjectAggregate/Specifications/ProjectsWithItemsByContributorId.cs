namespace Clean.Architecture.Core.ProjectAggregate.Specifications;

using Ardalis.Specification;

/// <summary>
/// TODO.
/// </summary>
public class ProjectsWithItemsByContributorIdSpec : Specification<Project>, ISingleResultSpecification
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ProjectsWithItemsByContributorIdSpec"/> class.
  /// </summary>
  /// <param name="contributorId">TODO.</param>
  public ProjectsWithItemsByContributorIdSpec(int contributorId)
  {
    Query
      .Where(project => project.Items.Where(item => item.ContributorId == contributorId).Any())
      .Include(project => project.Items);
  }
}

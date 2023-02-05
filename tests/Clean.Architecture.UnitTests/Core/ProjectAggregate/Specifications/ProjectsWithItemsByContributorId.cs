namespace Clean.Architecture.Core.ProjectAggregate.Specifications;

using Ardalis.Specification;

/// <summary>
/// The database query specification which gets a project with Items by Contributor Id.
/// </summary>
public sealed class ProjectsWithItemsByContributorIdSpec : Specification<Project>, ISingleResultSpecification
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ProjectsWithItemsByContributorIdSpec"/> class.
  /// </summary>
  /// <param name="contributorId">The Id of the contributor.</param>
  public ProjectsWithItemsByContributorIdSpec(int contributorId)
  {
    Query
      .Where(project => project.Items.Any(item => item.ContributorId == contributorId))
      .Include(project => project.Items);
  }
}

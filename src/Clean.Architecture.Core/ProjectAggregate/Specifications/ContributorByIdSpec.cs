namespace Clean.Architecture.Core.ProjectAggregate.Specifications;

using Ardalis.Specification;
using ContributorAggregate;

/// <summary>
/// TODO.
/// </summary>
public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ContributorByIdSpec"/> class.
  /// </summary>
  /// <param name="contributorId">TODO.</param>
  public ContributorByIdSpec(int contributorId)
  {
    Query
      .Where(contributor => contributor.Id == contributorId);
  }
}

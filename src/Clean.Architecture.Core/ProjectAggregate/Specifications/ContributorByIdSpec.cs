namespace Clean.Architecture.Core.ProjectAggregate.Specifications;

using Ardalis.Specification;
using ContributorAggregate;

/// <summary>
/// The database query specification which gets a Contributor by Id.
/// </summary>
public sealed class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ContributorByIdSpec"/> class.
  /// </summary>
  /// <param name="contributorId">The Id of the Contributor.</param>
  public ContributorByIdSpec(int contributorId)
  {
    Query
      .Where(contributor => contributor.Id == contributorId);
  }
}

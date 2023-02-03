namespace Clean.Architecture.Core.Services;

using Ardalis.Result;
using ContributorAggregate;
using ContributorAggregate.Events;
using Interfaces;
using Clean.Architecture.SharedKernel.Interfaces;
using MediatR;

/// <summary>
/// The ApplicationService which deletes a Contributor Aggregate object.
/// </summary>
public class DeleteContributorService : IDeleteContributorService
{
  private readonly IRepository<Contributor> _repository;
  private readonly IMediator _mediator;

  /// <summary>
  /// Initializes a new instance of the <see cref="DeleteContributorService"/> class.
  /// </summary>
  /// <param name="repository">TODO LATER.</param>
  /// <param name="mediator">TODO LATER2.</param>
  public DeleteContributorService(IRepository<Contributor> repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="contributorId">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  public async Task<Result> DeleteContributor(int contributorId)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(contributorId);
    if (aggregateToDelete == null)
    {
      return Result.NotFound();
    }

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new ContributorDeletedEvent(contributorId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}

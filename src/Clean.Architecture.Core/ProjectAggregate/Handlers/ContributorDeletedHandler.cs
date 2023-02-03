namespace Clean.Architecture.Core.ProjectAggregate.Handlers;

using Clean.Architecture.Core.ContributorAggregate.Events;
using Clean.Architecture.SharedKernel.Interfaces;
using Specifications;
using MediatR;

/// <summary>
/// TODO.
/// </summary>
public class ContributorDeletedHandler : INotificationHandler<ContributorDeletedEvent>
{
  private readonly IRepository<Project> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="ContributorDeletedHandler"/> class.
  /// </summary>
  /// <param name="repository"> TODO.</param>
  public ContributorDeletedHandler(IRepository<Project> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="domainEvent">TODO later1.</param>
  /// <param name="cancellationToken">TODO later2.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  public async Task Handle(ContributorDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    var projectSpec = new ProjectsWithItemsByContributorIdSpec(domainEvent.ContributorId);
    var projects = await _repository.ListAsync(projectSpec, cancellationToken);
    foreach (var project in projects)
    {
      project.Items
        .Where(item => item.ContributorId == domainEvent.ContributorId)
        .ToList()
        .ForEach(item => item.RemoveContributor());
      await _repository.UpdateAsync(project, cancellationToken);
    }
  }
}

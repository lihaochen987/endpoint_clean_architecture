namespace Clean.Architecture.Web.ProjectEndpoints;

using Core.ProjectAggregate;
using SharedKernel.Interfaces;
using FastEndpoints;

/// <summary>
/// The Project Delete endpoint.
/// </summary>
public class Delete : Endpoint<DeleteProjectRequest>
{
  private readonly IRepository<Project> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="Delete"/> class.
  /// </summary>
  /// <param name="repository">TODO LATER.</param>
  public Delete(IRepository<Project> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Overrides the FastApi Configure method and sets the route of the endpoint.
  /// </summary>
  public override void Configure()
  {
    Delete(DeleteProjectRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("ProjectEndpoints"));
  }

  /// <summary>
  /// Overrides the FastApi HandleAsync method and manipulates the business logic of the objects.
  /// </summary>
  /// <param name="request">The Project Request Delete contract object.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  public override async Task HandleAsync(DeleteProjectRequest request, CancellationToken cancellationToken)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(request.ProjectId, cancellationToken);
    if (aggregateToDelete == null)
    {
      ThrowError("Project not found.");
    }

    await _repository.DeleteAsync(aggregateToDelete, cancellationToken);

    await SendNoContentAsync(cancellationToken);
  }
}

namespace Clean.Architecture.Web.ProjectEndpoints;

using FastEndpoints;
using Core.ProjectAggregate;
using Core.ProjectAggregate.Specifications;
using SharedKernel.Interfaces;

/// <summary>
/// The Project GetById endpoint.
/// </summary>
public class GetById : Endpoint<GetProjectByIdRequest, GetProjectByIdResponse>
{
  private readonly IRepository<Project> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="GetById"/> class.
  /// </summary>
  /// <param name="repository">TODO LATER.</param>
  public GetById(IRepository<Project> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Overrides the FastApi Configure method and sets the route of the endpoint.
  /// </summary>
  public override void Configure()
  {
    Get(GetProjectByIdRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("ProjectEndpoints"));
  }

  /// <summary>
  /// Overrides the FastApi HandleAsync method and manipulates the business logic of the objects.
  /// </summary>
  /// <param name="request">The Project Request GetById contract object.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  public override async Task HandleAsync(GetProjectByIdRequest request, CancellationToken cancellationToken)
  {
    var spec = new ProjectByIdWithItemsSpec(request.ProjectId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var response = new GetProjectByIdResponse(
      id: entity.Id,
      name: entity.Name,
      items: entity.Items.Select(item => new ToDoItemRecord(item.Id, item.Title, item.Description, item.IsDone))
        .ToList());

    await SendAsync(response, cancellation: cancellationToken);
  }
}

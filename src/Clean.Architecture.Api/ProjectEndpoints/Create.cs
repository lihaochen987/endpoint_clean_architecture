namespace Clean.Architecture.Web.ProjectEndpoints;

using Core.ProjectAggregate;
using SharedKernel.Interfaces;
using FastEndpoints;

/// <summary>
/// The Project Create endpoint.
/// </summary>
public class Create : Endpoint<CreateProjectRequest, CreateProjectResponse>
{
  private readonly IRepository<Project> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="Create"/> class.
  /// </summary>
  /// <param name="repository">The Project repository.</param>
  public Create(IRepository<Project> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Overrides the FastApi Configure method and sets the route of the endpoint.
  /// </summary>
  public override void Configure()
  {
    Post(CreateProjectRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("ContributorEndpoints"));
  }

  /// <summary>
  /// Overrides the FastApi HandleAsync method and manipulates the business logic of the objects.
  /// </summary>
  /// <param name="request">The Project Request Create contract object.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  public override async Task HandleAsync(CreateProjectRequest request, CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      ThrowError("Name is required");
    }

    var newProject = new Project(request.Name, PriorityStatus.Backlog);
    var createdItem = await _repository.AddAsync(newProject, cancellationToken);
    var response = new CreateProjectResponse(
      id: createdItem.Id,
      name: createdItem.Name);

    await SendAsync(response, cancellation: cancellationToken);
  }
}

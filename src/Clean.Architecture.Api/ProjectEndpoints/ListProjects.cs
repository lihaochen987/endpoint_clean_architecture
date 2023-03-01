namespace Clean.Architecture.Web.ProjectEndpoints;

using FastEndpoints;
using Core.ProjectAggregate;
using SharedKernel.Interfaces;

/// <summary>
/// The list Projects endpoint.
/// </summary>
public class ListProjects : EndpointWithoutRequest<ProjectListResponse>
{
  private readonly IReadRepository<Project> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="ListProjects"/> class.
  /// </summary>
  /// <param name="repository">The Project repository.</param>
  public ListProjects(IReadRepository<Project> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Overrides the FastApi Configure method and sets the route of the endpoint.
  /// </summary>
  public override void Configure()
  {
    Get("/Projects");
    AllowAnonymous();
    Options(x => x
      .WithTags("ProjectEndpoints"));
  }

  /// <summary>
  /// Overrides the FastApi HandleAsync method and manipulates the business logic of the objects.
  /// </summary>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var projects = await _repository.ListAsync(cancellationToken);
    var response = new ProjectListResponse
    {
      Projects = projects
        .Select(project => new ProjectRecord(project.Id, project.Name))
        .ToList(),
    };

    await SendAsync(response, cancellation: cancellationToken);
  }
}

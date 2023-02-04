namespace Clean.Architecture.Web.Endpoints.ProjectEndpoints;

using Ardalis.ApiEndpoints;
using Core.ProjectAggregate;
using SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// TODO.
/// </summary>
public class List : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult<ProjectListResponse>
{
  private readonly IReadRepository<Project> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="List"/> class.
  /// </summary>
  /// <param name="repository">TODO LATER.</param>
  public List(IReadRepository<Project> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="cancellationToken">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  [HttpGet("/Projects")]
  [SwaggerOperation(
    Summary = "Gets a list of all Projects",
    Description = "Gets a list of all Projects",
    OperationId = "Project.List",
    Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<ProjectListResponse>> HandleAsync(
    CancellationToken cancellationToken = new ())
  {
    var projects = await _repository.ListAsync(cancellationToken);
    var response = new ProjectListResponse
    {
      Projects = projects
        .Select(project => new ProjectRecord(project.Id, project.Name))
        .ToList(),
    };

    return Ok(response);
  }
}

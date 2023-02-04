namespace Clean.Architecture.Web.Endpoints.ProjectEndpoints;
using Ardalis.ApiEndpoints;
using Core.ProjectAggregate;
using SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// TODO.
/// </summary>
public class Create : EndpointBaseAsync
  .WithRequest<CreateProjectRequest>
  .WithActionResult<CreateProjectResponse>
{
  private readonly IRepository<Project> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="Create"/> class.
  /// </summary>
  /// <param name="repository">TODO LATER.</param>
  public Create(IRepository<Project> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="request">TODO LATER.</param>
  /// <param name="cancellationToken">TODO LATER2.</param>
  /// <returns>TODO LATER3.</returns>
  [HttpPost("/Projects")]
  [SwaggerOperation(
    Summary = "Creates a new Project",
    Description = "Creates a new Project",
    OperationId = "Project.Create",
    Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<CreateProjectResponse>> HandleAsync(
    CreateProjectRequest request,
    CancellationToken cancellationToken = new ())
  {
    if (request.Name == null)
    {
      return BadRequest();
    }

    var newProject = new Project(request.Name, PriorityStatus.Backlog);
    var createdItem = await _repository.AddAsync(newProject, cancellationToken);
    var response = new CreateProjectResponse(
      id: createdItem.Id,
      name: createdItem.Name);

    return Ok(response);
  }
}

namespace Clean.Architecture.Web.ProjectEndpoints;

using Ardalis.ApiEndpoints;
using Core.ProjectAggregate;
using SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// TODO.
/// </summary>
public class Update : EndpointBaseAsync
  .WithRequest<UpdateProjectRequest>
  .WithActionResult<UpdateProjectResponse>
{
  private readonly IRepository<Project> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="Update"/> class.
  /// </summary>
  /// <param name="repository">TODO LATER.</param>
  public Update(IRepository<Project> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="request">TODO LATER.</param>
  /// <param name="cancellationToken">TODO LATER 2.</param>
  /// <returns>TODO LATER 3.</returns>
  [HttpPut(UpdateProjectRequest.Route)]
  [SwaggerOperation(
    Summary = "Updates a Project",
    Description = "Updates a Project with a longer description",
    OperationId = "Projects.Update",
    Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<UpdateProjectResponse>> HandleAsync(
    UpdateProjectRequest request,
    CancellationToken cancellationToken = new ())
  {
    if (request.Name == null)
    {
      return BadRequest();
    }

    var existingProject = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (existingProject == null)
    {
      return NotFound();
    }

    existingProject.UpdateName(request.Name);

    await _repository.UpdateAsync(existingProject, cancellationToken);

    var response = new UpdateProjectResponse(
      project: new ProjectRecord(existingProject.Id, existingProject.Name));

    return Ok(response);
  }
}

namespace Clean.Architecture.Web.Endpoints.ProjectEndpoints;

using Ardalis.ApiEndpoints;
using Core.ProjectAggregate;
using SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// TODO.
/// </summary>
public class Delete : EndpointBaseAsync
  .WithRequest<DeleteProjectRequest>
  .WithoutResult
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
  /// TODO.
  /// </summary>
  /// <param name="request">TODO LATER.</param>
  /// <param name="cancellationToken">TODO LATER2.</param>
  /// <returns>TODO LATER3.</returns>
  [HttpDelete(DeleteProjectRequest.Route)]
  [SwaggerOperation(
    Summary = "Deletes a Project",
    Description = "Deletes a Project",
    OperationId = "Projects.Delete",
    Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(
    [FromRoute] DeleteProjectRequest request,
    CancellationToken cancellationToken = new ())
  {
    var aggregateToDelete = await _repository.GetByIdAsync(request.ProjectId, cancellationToken);
    if (aggregateToDelete == null)
    {
      return NotFound();
    }

    await _repository.DeleteAsync(aggregateToDelete, cancellationToken);

    return NoContent();
  }
}

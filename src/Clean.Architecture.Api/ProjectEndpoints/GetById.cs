namespace Clean.Architecture.Web.Endpoints.ProjectEndpoints;

using Ardalis.ApiEndpoints;
using Core.ProjectAggregate;
using Core.ProjectAggregate.Specifications;
using SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// TODO.
/// </summary>
public class GetById : EndpointBaseAsync
  .WithRequest<GetProjectByIdRequest>
  .WithActionResult<GetProjectByIdResponse>
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
  /// TODO.
  /// </summary>
  /// <param name="request">TODO LATER.</param>
  /// <param name="cancellationToken">TODO LATER2.</param>
  /// <returns>TODO LATER3.</returns>
  [HttpGet(GetProjectByIdRequest.Route)]
  [SwaggerOperation(
    Summary = "Gets a single Project",
    Description = "Gets a single Project by Id",
    OperationId = "Projects.GetById",
    Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<GetProjectByIdResponse>> HandleAsync(
    [FromRoute] GetProjectByIdRequest request,
    CancellationToken cancellationToken = new ())
  {
    var spec = new ProjectByIdWithItemsSpec(request.ProjectId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }

    var response = new GetProjectByIdResponse(
      id: entity.Id,
      name: entity.Name,
      items: entity.Items.Select(item => new ToDoItemRecord(item.Id, item.Title, item.Description, item.IsDone))
        .ToList());

    return Ok(response);
  }
}

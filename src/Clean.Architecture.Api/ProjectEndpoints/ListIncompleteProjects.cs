namespace Clean.Architecture.Web.ProjectEndpoints;

using Ardalis.ApiEndpoints;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// TODO.
/// </summary>
public class ListIncompleteProjects : EndpointBaseAsync
  .WithRequest<ListIncompleteRequest>
  .WithActionResult<ListIncompleteResponse>
{
  private readonly IToDoItemSearchService _searchService;

  /// <summary>
  /// Initializes a new instance of the <see cref="ListIncompleteProjects"/> class.
  /// </summary>
  /// <param name="searchService">TODO LATER2.</param>
  public ListIncompleteProjects(IToDoItemSearchService searchService)
  {
    _searchService = searchService;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="request">TODO LATER2.</param>
  /// <param name="cancellationToken">TODO LATER3.</param>
  /// <returns>TODO LATER4.</returns>
  [HttpGet("/Projects/{ProjectId}/IncompleteItems")]
  [SwaggerOperation(
    Summary = "Gets a list of a project's incomplete items",
    Description = "Gets a list of a project's incomplete items",
    OperationId = "Project.ListIncomplete",
    Tags = new[] { "ProjectEndpoints" })
  ]
  public override async Task<ActionResult<ListIncompleteResponse>> HandleAsync(
    [FromQuery] ListIncompleteRequest request,
    CancellationToken cancellationToken = new ())
  {
    if (request.SearchString == null)
    {
      return BadRequest();
    }

    var response = new ListIncompleteResponse(0, new List<ToDoItemRecord>());
    var result = await _searchService.GetAllIncompleteItemsAsync(request.ProjectId, request.SearchString);

    if (result.Status == Ardalis.Result.ResultStatus.Ok)
    {
      response.ProjectId = request.ProjectId;
      response.IncompleteItems = new List<ToDoItemRecord>(
        result.Value.Select(
          item => new ToDoItemRecord(
              item.Id,
              item.Title,
              item.Description,
              item.IsDone)));
    }
    else if (result.Status == Ardalis.Result.ResultStatus.Invalid)
    {
      return BadRequest(result.ValidationErrors);
    }
    else if (result.Status == Ardalis.Result.ResultStatus.NotFound)
    {
      return NotFound();
    }

    return Ok(response);
  }
}

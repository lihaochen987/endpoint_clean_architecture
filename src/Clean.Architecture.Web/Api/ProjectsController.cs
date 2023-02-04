namespace Clean.Architecture.Web.Api;

using Core.ProjectAggregate;
using Core.ProjectAggregate.Specifications;
using SharedKernel.Interfaces;
using ApiModels;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// A sample API Controller. Consider using API Endpoints (see Endpoints folder) for a more SOLID approach to building APIs
/// https://github.com/ardalis/ApiEndpoints.
/// </summary>
public class ProjectsController : BaseApiController
{
  private readonly IRepository<Project> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="ProjectsController"/> class.
  /// </summary>
  /// <param name="repository">TODO.</param>
  public ProjectsController(IRepository<Project> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// TODO.
  /// GET: api/Projects.
  /// </summary>
  /// <returns>TODO LATER.</returns>
  [HttpGet]
  public async Task<IActionResult> List()
  {
    var projectDTOs = (await _repository.ListAsync())
      .Select(project => new ProjectDTO(
        id: project.Id,
        name: project.Name))
      .ToList();

    return Ok(projectDTOs);
  }

  /// <summary>
  /// TODO.
  /// GET: api/Projects.
  /// </summary>
  /// <param name="id">TODO.</param>
  /// <returns>TODO LATER.</returns>
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetById(int id)
  {
    var projectSpec = new ProjectByIdWithItemsSpec(id);
    var project = await _repository.FirstOrDefaultAsync(projectSpec);
    if (project == null)
    {
      return NotFound();
    }

    var result = new ProjectDTO(
      id: project.Id,
      name: project.Name,
      items: new List<ToDoItemDTO>(
        project.Items.Select(ToDoItemDTO.FromToDoItem).ToList()));

    return Ok(result);
  }

  /// <summary>
  /// TODO.
  /// POST: api/Projects.
  /// </summary>
  /// <param name="request">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  [HttpPost]
  public async Task<IActionResult> Post([FromBody] CreateProjectDTO request)
  {
    var newProject = new Project(request.Name, PriorityStatus.Backlog);

    var createdProject = await _repository.AddAsync(newProject);

    var result = new ProjectDTO(
      id: createdProject.Id,
      name: createdProject.Name);
    return Ok(result);
  }

  /// <summary>
  /// TODO.
  /// PATCH: api/Projects/{projectId}/complete/{itemId}.
  /// </summary>
  /// <param name="projectId">TODO LATER.</param>
  /// <param name="itemId">TODO LATER2.</param>
  /// <returns>TODO LATER3.</returns>
  [HttpPatch("{projectId:int}/complete/{itemId}")]
  public async Task<IActionResult> Complete(int projectId, int itemId)
  {
    var projectSpec = new ProjectByIdWithItemsSpec(projectId);
    var project = await _repository.FirstOrDefaultAsync(projectSpec);
    if (project == null)
    {
      return NotFound("No such project");
    }

    var toDoItem = project.Items.FirstOrDefault(item => item.Id == itemId);
    if (toDoItem == null)
    {
      return NotFound("No such item.");
    }

    toDoItem.MarkComplete();
    await _repository.UpdateAsync(project);

    return Ok();
  }
}

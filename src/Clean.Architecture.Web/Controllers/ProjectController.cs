namespace Clean.Architecture.Web.Controllers;

using Core.ProjectAggregate;
using Core.ProjectAggregate.Specifications;
using SharedKernel.Interfaces;
using ViewModels;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// TODO.
/// </summary>
[Route("[controller]")]
public class ProjectController : Controller
{
  private readonly IRepository<Project> _projectRepository;

  /// <summary>
  /// Initializes a new instance of the <see cref="ProjectController"/> class.
  /// </summary>
  /// <param name="projectRepository">TODO LATER.</param>
  public ProjectController(IRepository<Project> projectRepository)
  {
    _projectRepository = projectRepository;
  }

  /// <summary>
  /// TODO.
  /// GET project/{projectId?}.
  /// </summary>
  /// <param name="projectId">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  [HttpGet("{projectId:int}")]
  public async Task<IActionResult> Index(int projectId = 1)
  {
    var spec = new ProjectByIdWithItemsSpec(projectId);
    var project = await _projectRepository.FirstOrDefaultAsync(spec);
    if (project == null)
    {
      return NotFound();
    }

    var dto = new ProjectViewModel
    {
      Id = project.Id,
      Name = project.Name,
      Items = project.Items
        .Select(ToDoItemViewModel.FromToDoItem)
        .ToList(),
    };
    return View(dto);
  }
}

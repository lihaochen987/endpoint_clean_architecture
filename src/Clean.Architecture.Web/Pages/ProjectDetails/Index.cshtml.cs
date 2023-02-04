namespace Clean.Architecture.Web.Pages.ProjectDetails;

using Core.ProjectAggregate;
using Core.ProjectAggregate.Specifications;
using SharedKernel.Interfaces;
using ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

/// <summary>
/// TODO.
/// </summary>
public class IndexModel : PageModel
{
  /// <summary>
  /// TODO.
  /// </summary>
  private readonly IRepository<Project> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="IndexModel"/> class.
  /// </summary>
  /// <param name="repository">TODO.</param>
  public IndexModel(IRepository<Project> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Gets or sets the ProjectId.
  /// </summary>
  [BindProperty(SupportsGet = true)]
  public int ProjectId { get; set; }

  /// <summary>
  /// Gets or sets the message.
  /// </summary>
  public string Message { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the project.
  /// </summary>
  public ProjectDTO? Project { get; set; }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  public async Task OnGetAsync()
  {
    var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
    var project = await _repository.FirstOrDefaultAsync(projectSpec);
    if (project == null)
    {
      Message = "No project found.";

      return;
    }

    Project = new ProjectDTO(
      id: project.Id,
      name: project.Name,
      items: project.Items
        .Select(ToDoItemDTO.FromToDoItem)
        .ToList());
  }
}

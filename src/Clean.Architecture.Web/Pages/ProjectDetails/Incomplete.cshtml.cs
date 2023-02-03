namespace Clean.Architecture.Web.Pages.ProjectDetails;

using Core.ProjectAggregate;
using Core.ProjectAggregate.Specifications;
using SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

/// <summary>
/// TODO.
/// </summary>
public class IncompleteModel : PageModel
{
  /// <summary>
  /// TODO.
  /// </summary>
  private readonly IRepository<Project> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="IncompleteModel"/> class.
  /// </summary>
  /// <param name="repository">TODO LATER.</param>
  public IncompleteModel(IRepository<Project> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Gets or sets the ProjectId.
  /// </summary>
  [BindProperty(SupportsGet = true)]
  public int ProjectId { get; set; }

  /// <summary>
  /// Gets or sets the to-do items.
  /// </summary>
  public List<ToDoItem>? ToDoItems { get; set; }

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
      return;
    }

    var spec = new IncompleteItemsSpec();

    ToDoItems = spec.Evaluate(project.Items).ToList();
  }
}

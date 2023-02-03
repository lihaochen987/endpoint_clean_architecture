namespace Clean.Architecture.Core.Services;

using Ardalis.Result;
using Interfaces;
using ProjectAggregate;
using ProjectAggregate.Specifications;
using Clean.Architecture.SharedKernel.Interfaces;

/// <summary>
/// The ApplicationService which searches a ToDoItem.
/// </summary>
public class ToDoItemSearchService : IToDoItemSearchService
{
  private readonly IRepository<Project> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="ToDoItemSearchService"/> class.
  /// </summary>
  /// <param name="repository">The Project Aggregate object.</param>
  public ToDoItemSearchService(IRepository<Project> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="projectId">TODO LATER.</param>
  /// <param name="searchString">TODO LATER2.</param>
  /// <returns>TODO LATER3.</returns>
  public async Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString)
  {
    if (string.IsNullOrEmpty(searchString))
    {
      var errors = new List<ValidationError>
      {
        new () { Identifier = nameof(searchString), ErrorMessage = $"{nameof(searchString)} is required." },
      };

      return Result<List<ToDoItem>>.Invalid(errors);
    }

    var projectSpec = new ProjectByIdWithItemsSpec(projectId);
    var project = await _repository.FirstOrDefaultAsync(projectSpec);

    // TODO: Optionally use Ardalis.GuardClauses Guard.Against.NotFound and catch
    if (project == null)
    {
      return Result<List<ToDoItem>>.NotFound();
    }

    var incompleteSpec = new IncompleteItemsSearchSpec(searchString);
    try
    {
      var items = incompleteSpec.Evaluate(project.Items).ToList();

      return new Result<List<ToDoItem>>(items);
    }
    catch (Exception ex)
    {
      // TODO: Log details here
      return Result<List<ToDoItem>>.Error(new[] { ex.Message });
    }
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="projectId">TODO LATER1.</param>
  /// <returns>TODO LATER2.</returns>
  public async Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId)
  {
    var projectSpec = new ProjectByIdWithItemsSpec(projectId);
    var project = await _repository.FirstOrDefaultAsync(projectSpec);
    if (project == null)
    {
      return Result<ToDoItem>.NotFound();
    }

    var incompleteSpec = new IncompleteItemsSpec();
    var items = incompleteSpec.Evaluate(project.Items).ToList();
    if (!items.Any())
    {
      return Result<ToDoItem>.NotFound();
    }

    return new Result<ToDoItem>(items.First());
  }
}

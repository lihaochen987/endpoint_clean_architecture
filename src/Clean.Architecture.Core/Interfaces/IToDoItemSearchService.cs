namespace Clean.Architecture.Core.Interfaces;

using Ardalis.Result;
using ProjectAggregate;

/// <summary>
/// The interface for searching the To-do item.
/// </summary>
public interface IToDoItemSearchService
{
  /// <summary>
  /// Retrieves the next incomplete To-do item.
  /// </summary>
  /// <param name="projectId">The projectId of the To-do item.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);

  /// <summary>
  /// Gets all incomplete To-do items.
  /// </summary>
  /// <param name="projectId">The projectId of the To-do item.</param>
  /// <param name="searchString">TODO.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}

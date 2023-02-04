namespace Clean.Architecture.Web.ViewModels;

using Core.ProjectAggregate;

/// <summary>
/// TODO.
/// </summary>
public class ToDoItemViewModel
{
  /// <summary>
  /// Gets tODO.
  /// </summary>
  public string? Title { get; private init; }

  /// <summary>
  /// Gets tODO.
  /// </summary>
  public string? Description { get; private init; }

  /// <summary>
  /// Gets tODO.
  /// </summary>
  private int Id { get; init; }

  /// <summary>
  /// Gets a value indicating whether tODO.
  /// </summary>
  private bool IsDone { get; init; }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="item">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  public static ToDoItemViewModel FromToDoItem(ToDoItem item)
  {
    return new ToDoItemViewModel()
    {
      Id = item.Id, Title = item.Title, Description = item.Description, IsDone = item.IsDone,
    };
  }
}

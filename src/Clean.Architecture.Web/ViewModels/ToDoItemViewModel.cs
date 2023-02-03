namespace Clean.Architecture.Web.ViewModels;

using Core.ProjectAggregate;

/// <summary>
/// TODO.
/// </summary>
public class ToDoItemViewModel
{
  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public string? Title { get; set; }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public string? Description { get; set; }

  /// <summary>
  /// Gets a value indicating whether tODO.
  /// </summary>
  public bool IsDone { get; private set; }

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

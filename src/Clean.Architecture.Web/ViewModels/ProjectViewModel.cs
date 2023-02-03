namespace Clean.Architecture.Web.ViewModels;

using System.Collections.Generic;

/// <summary>
/// TODO.
/// </summary>
public class ProjectViewModel
{
  /// <summary>
  /// TODO.
  /// </summary>
  public List<ToDoItemViewModel> Items = new ();

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public string? Name { get; set; }
}

namespace Clean.Architecture.Web.ApiModels;

using System.ComponentModel.DataAnnotations;
using Core.ProjectAggregate;

/// <summary>
/// TODO.
/// ApiModel DTOs are used by ApiController classes and are typically kept in a side-by-side folder.
/// </summary>
public class ToDoItemDTO
{
  /// <summary>
  /// Gets the Title of the to-do item DTO.
  /// </summary>
  [Required]
  public string? Title { get; private init; }

  /// <summary>
  /// Gets the description of the to-do item DTO.
  /// </summary>
  public string? Description { get; private init; }

  /// <summary>
  /// Gets a value indicating whether the to-do item DTO is done.
  /// </summary>
  public bool IsDone { get; private init; }

  /// <summary>
  /// Gets id of the to-do item DTO.
  /// </summary>
  private int Id { get; init; }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="item">TODO LATER.</param>
  /// <returns>TODO LATER2.</returns>
  public static ToDoItemDTO FromToDoItem(ToDoItem item)
  {
    return new ToDoItemDTO() { Id = item.Id, Title = item.Title, Description = item.Description, IsDone = item.IsDone };
  }
}

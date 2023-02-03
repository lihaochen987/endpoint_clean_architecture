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
  /// Gets or sets Id of the to-do item DTO.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Gets or sets the Title of the to-do item DTO.
  /// </summary>
  [Required]
  public string? Title { get; set; }

  /// <summary>
  /// Gets or sets the description of the to-do item DTO.
  /// </summary>
  public string? Description { get; set; }

  /// <summary>
  /// Gets a value indicating whether the to-do item DTO is done.
  /// </summary>
  public bool IsDone { get; private set; }

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

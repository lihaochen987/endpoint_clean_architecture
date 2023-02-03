namespace Clean.Architecture.Core.ProjectAggregate.Specifications;

using Ardalis.Specification;

/// <summary>
/// TODO.
/// </summary>
public class IncompleteItemsSearchSpec : Specification<ToDoItem>
{
  /// <summary>
  /// Initializes a new instance of the <see cref="IncompleteItemsSearchSpec"/> class.
  /// </summary>
  /// <param name="searchString">TODO.</param>
  public IncompleteItemsSearchSpec(string searchString)
  {
    Query
      .Where(item => !item.IsDone &&
                     (item.Title.Contains(searchString) ||
                      item.Description.Contains(searchString)));
  }
}

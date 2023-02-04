namespace Clean.Architecture.Core.ProjectAggregate.Specifications;

using Ardalis.Specification;

/// <summary>
/// The database query specification which gets a searches Incomplete items.
/// </summary>
public sealed class IncompleteItemsSearchSpec : Specification<ToDoItem>
{
  /// <summary>
  /// Initializes a new instance of the <see cref="IncompleteItemsSearchSpec"/> class.
  /// </summary>
  /// <param name="searchString">The search string to find the Incomplete items.</param>
  public IncompleteItemsSearchSpec(string searchString)
  {
    Query
      .Where(item => !item.IsDone &&
                     (item.Title.Contains(searchString) ||
                      item.Description.Contains(searchString)));
  }
}

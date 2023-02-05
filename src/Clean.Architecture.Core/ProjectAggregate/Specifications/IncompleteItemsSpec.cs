namespace Clean.Architecture.Core.ProjectAggregate.Specifications;

using Ardalis.Specification;

/// <summary>
/// The database query specification which gets all Incomplete items.
/// </summary>
public sealed class IncompleteItemsSpec : Specification<ToDoItem>
{
  /// <summary>
  /// Initializes a new instance of the <see cref="IncompleteItemsSpec"/> class.
  /// </summary>
  public IncompleteItemsSpec()
  {
    Query.Where(item => !item.IsDone);
  }
}

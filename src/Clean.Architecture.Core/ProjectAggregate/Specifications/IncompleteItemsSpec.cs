namespace Clean.Architecture.Core.ProjectAggregate.Specifications;

using Ardalis.Specification;

/// <summary>
/// TODO.
/// </summary>
public class IncompleteItemsSpec : Specification<ToDoItem>
{
  /// <summary>
  /// Initializes a new instance of the <see cref="IncompleteItemsSpec"/> class.
  /// </summary>
  public IncompleteItemsSpec()
  {
    Query.Where(item => !item.IsDone);
  }
}

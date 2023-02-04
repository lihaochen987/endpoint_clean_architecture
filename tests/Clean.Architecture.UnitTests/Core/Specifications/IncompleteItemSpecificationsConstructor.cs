﻿namespace Clean.Architecture.UnitTests.Core.Specifications;

using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.Core.ProjectAggregate.Specifications;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
public class IncompleteItemsSpecificationConstructor
{
  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void FilterCollectionToOnlyReturnItemsWithIsDoneFalse()
  {
    var item1 = new ToDoItem();
    var item2 = new ToDoItem();
    var item3 = new ToDoItem();
    item3.MarkComplete();

    var items = new List<ToDoItem>() { item1, item2, item3 };

    var spec = new IncompleteItemsSpec();

    var filteredList = spec.Evaluate(items);

    IEnumerable<ToDoItem> toDoItems = filteredList.ToList();
    Assert.Contains(item1, toDoItems);
    Assert.Contains(item2, toDoItems);
    Assert.DoesNotContain(item3, toDoItems);
  }
}

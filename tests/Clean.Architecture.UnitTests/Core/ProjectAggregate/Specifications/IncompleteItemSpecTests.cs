namespace Clean.Architecture.UnitTests.Core.ProjectAggregate.Specifications;

using Clean.Architecture.Core.ProjectAggregate.Specifications;
using Architecture.Core.ProjectAggregate;
using Builders;
using Shouldly;
using Xunit;

/// <summary>
/// Tests getting all incomplete items.
/// </summary>
public class IncompleteItemSpecTests
{
  /// <summary>
  /// Tests getting all the incomplete to-do items.
  /// </summary>
  [Fact]
  public void SuccessfullyGetsAllIncompleteItems()
  {
    // Arrange
    var spec = new IncompleteItemsSpec();

    // Act
    var result = spec.Evaluate(GetAllIncompleteItems()).ToList();

    // Assert
    result.Count().ShouldBe(3);
    result.First().ShouldBeAssignableTo<ToDoItem>();
  }

  private List<ToDoItem> GetAllIncompleteItems()
  {
    var toDoItemOne = new ToDoItemBuilder().WithDefaultValues().Id(1).IsDone(false).Build();
    var toDoItemTwo = new ToDoItemBuilder().WithDefaultValues().Id(2).IsDone(false).Build();
    var toDoItemThree = new ToDoItemBuilder().WithDefaultValues().Id(3).IsDone(false).Build();

    return new List<ToDoItem> { toDoItemOne, toDoItemTwo, toDoItemThree, };
  }
}

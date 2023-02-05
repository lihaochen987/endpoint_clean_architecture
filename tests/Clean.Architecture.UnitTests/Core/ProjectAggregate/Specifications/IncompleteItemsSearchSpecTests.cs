namespace Clean.Architecture.UnitTests.Core.ProjectAggregate.Specifications;

using Architecture.Core.ProjectAggregate;
using Clean.Architecture.Core.ProjectAggregate.Specifications;
using Builders;
using Shouldly;
using Xunit;

/// <summary>
/// Tests searching incomplete items by string.
/// </summary>
public class IncompleteItemsSearchSpecTests
{
  private readonly string _testTodoTitle = "Test";

  /// <summary>
  /// Tests whether a to-do item can successfully be retrieved by string.
  /// </summary>
  [Fact]
  public void SuccessfullyGetsIncompleteItemBySearchSpec()
  {
    // Arrange
    var spec = new IncompleteItemsSearchSpec(_testTodoTitle);

    // Act
    var result = spec.Evaluate(GetSingleItem()).FirstOrDefault();

    // Assert
    result.ShouldNotBeNull();
    result.Title.ShouldBe("Test Title");
  }

  private List<ToDoItem> GetSingleItem()
  {
    var toDoItemOne = new ToDoItemBuilder().WithDefaultValues().Id(1).IsDone(false).Title("Test Title").Build();
    var toDoItemTwo = new ToDoItemBuilder().WithDefaultValues().Id(2).IsDone(false).Build();
    var toDoItemThree = new ToDoItemBuilder().WithDefaultValues().Id(3).IsDone(false).Build();

    return new List<ToDoItem> { toDoItemOne, toDoItemTwo, toDoItemThree, };
  }
}

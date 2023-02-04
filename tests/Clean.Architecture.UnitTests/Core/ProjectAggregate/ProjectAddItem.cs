namespace Clean.Architecture.UnitTests.Core.ProjectAggregate;

using Clean.Architecture.Core.ProjectAggregate;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
public class ProjectAddItem
{
  /// <summary>
  /// TODO.
  /// </summary>
  private readonly Project _testProject = new Project("some name", PriorityStatus.Backlog);

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void AddsItemToItems()
  {
    // Arrange
    var testItem = new ToDoItem("title", "description");

    // Act
    _testProject.AddItem(testItem);

    // Assert
    Assert.Contains(testItem, _testProject.Items);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void ThrowsExceptionGivenNullItem()
  {
    // Act
    void Action()
    {
      _testProject.AddItem(null!);
    }

    // Assert
    var ex = Assert.Throws<ArgumentNullException>(Action);
    Assert.Equal("newItem", ex.ParamName);
  }
}

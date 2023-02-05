namespace Clean.Architecture.UnitTests.Core.ProjectAggregate.Project;

using Clean.Architecture.Core.ProjectAggregate;
using Xunit;

/// <summary>
/// Tests the AddItem method of Project.
/// </summary>
public class ProjectAddItem
{
  /// <summary>
  /// Initialises the Project object.
  /// </summary>
  private readonly Project _testProject = new ("some name", PriorityStatus.Backlog);

  /// <summary>
  /// Successfully adds items to the project.
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
  /// Successfully throws an exception when the item is null.
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

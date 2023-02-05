namespace Clean.Architecture.UnitTests.Core.ProjectAggregate;

using Xunit;
using Clean.Architecture.Core.ProjectAggregate;
using Shouldly;
using Builders;

/// <summary>
/// Tests relating to the Project domain model object.
/// </summary>
public class ProjectTests
{
  /// <summary>
  /// Successfully adds items to the project.
  /// </summary>
  [Fact]
  public void AddsItemToItems()
  {
    // Arrange
    var item = new ToDoItemBuilder().WithDefaultValues().Title("title").Description("description").Build();
    var project = new ProjectBuilder().WithDefaultValues().Build();

    // Act
    project.AddItem(item);

    // Assert
    Assert.Contains(item, project.Items);
  }

  /// <summary>
  /// Successfully throws an exception when the item is null.
  /// </summary>
  [Fact]
  public void ThrowsExceptionGivenNullItem()
  {
    // Arrange
    var project = new ProjectBuilder().WithDefaultValues().Build();

    // Act
    void Action()
    {
      project.AddItem(null!);
    }

    // Assert
    var ex = Assert.Throws<ArgumentNullException>(Action);
    ex.ParamName.ShouldBe("newItem");
  }

  /// <summary>
  /// Whether the Name is successfully updated.
  /// </summary>
  [Fact]
  public void NameSuccessfullyUpdated()
  {
    // Arrange
    var project = new ProjectBuilder().WithDefaultValues().Name("TestProjectName1").Build();

    // Act
    project.UpdateName("TestProjectName2");

    // Assert
    project.Name.ShouldBe("TestProjectName2");
  }

  /// <summary>
  /// Whether the Project Status is correct.
  /// </summary>
  [Fact]
  public void SuccessfullyGetsStatusOfItems()
  {
    // Arrange
    var itemOne = new ToDoItemBuilder().WithDefaultValues().IsDone(true).Build();
    var itemTwo = new ToDoItemBuilder().WithDefaultValues().IsDone(true).Build();
    var itemThree = new ToDoItemBuilder().WithDefaultValues().IsDone(false).Build();
    var items = new List<ToDoItem> { itemOne, itemTwo, itemThree };
    var project = new ProjectBuilder().WithDefaultValues().Name("TestProjectName1").Items(items).Build();

    // Act
    var result = project.Status;

    // Assert
    result.ShouldBe(ProjectStatus.InProgress);
  }
}

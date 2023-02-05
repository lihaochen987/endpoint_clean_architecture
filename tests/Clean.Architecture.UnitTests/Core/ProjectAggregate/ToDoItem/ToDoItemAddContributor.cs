namespace Clean.Architecture.UnitTests.Core.ProjectAggregate.ToDoItem;

using Shouldly;
using Builders;
using Xunit;

/// <summary>
/// Tests the AddContributor method of the ToDoItem.
/// </summary>
public class ToDoItemAddContributor
{
  /// <summary>
  /// Successfully adds a Contributor id to the ToDoItem.
  /// </summary>
  [Fact]
  public void SuccessfullyAddContributor()
  {
    // Arrange
    var toDoItem = new ToDoItemBuilder().WithDefaultValues().Build();

    // Act
    toDoItem.AddContributor(19);

    // Assert
    toDoItem.ContributorId.ShouldBe(19);
  }
}

namespace Clean.Architecture.UnitTests.Core.ProjectAggregate.ToDoItem;

using Builders;
using Shouldly;
using Xunit;

/// <summary>
/// Tests the RemoveContributor method of the to-do item object.
/// </summary>
public class ToDoItemRemoveContributor
{
  /// <summary>
  /// Successfully removes a Contributor.
  /// </summary>
  [Fact]
  public void SuccessfullyRemovesContributor()
  {
    // Arrange
    var toDoItem = new ToDoItemBuilder().WithDefaultValues().Contributor(5).Build();

    // Act
    toDoItem.RemoveContributor();

    // Assert
    toDoItem.ContributorId.ShouldBe(null);
  }
}

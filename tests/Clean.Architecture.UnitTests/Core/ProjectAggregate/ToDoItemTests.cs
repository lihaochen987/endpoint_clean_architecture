namespace Clean.Architecture.UnitTests.Core.ProjectAggregate;

using Clean.Architecture.Core.ProjectAggregate.Events;
using Builders;
using Shouldly;
using Xunit;

/// <summary>
/// Tests relating to the to-do item domain model object.
/// </summary>
public class ToDoItemTests
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

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void SetsIsDoneToTrue()
  {
    // Arrange
    var item = new ToDoItemBuilder()
      .WithDefaultValues()
      .Description(string.Empty)
      .Build();

    // Act
    item.MarkComplete();

    // Assert
    item.IsDone.ShouldBe(true);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void RaisesToDoItemCompletedEvent()
  {
    // Arrange
    var item = new ToDoItemBuilder().Build();

    // Act
    item.MarkComplete();

    // Assert
    item.DomainEvents.Count().ShouldBe(1);
    item.DomainEvents.First().ShouldBeOfType<ToDoItemCompletedEvent>();
  }

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

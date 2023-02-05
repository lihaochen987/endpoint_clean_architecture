namespace Clean.Architecture.UnitTests.Core.ProjectAggregate.ToDoItem;

using Shouldly;
using Clean.Architecture.Core.ProjectAggregate.Events;
using Builders;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
public class ToDoItemMarkComplete
{
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
}

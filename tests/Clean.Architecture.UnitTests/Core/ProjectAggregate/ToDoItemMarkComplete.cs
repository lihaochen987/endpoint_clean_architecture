namespace Clean.Architecture.UnitTests.Core.ProjectAggregate;

using Builders;
using Clean.Architecture.Core.ProjectAggregate.Events;
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
    Assert.True(item.IsDone);
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
    Assert.Single(item.DomainEvents);
    Assert.IsType<ToDoItemCompletedEvent>(item.DomainEvents.First());
  }
}

namespace Clean.Architecture.UnitTests.Core.ProjectAggregate;

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
    var item = new ToDoItemBuilder()
      .WithDefaultValues()
      .Description(string.Empty)
      .Build();

    item.MarkComplete();

    Assert.True(item.IsDone);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void RaisesToDoItemCompletedEvent()
  {
    var item = new ToDoItemBuilder().Build();

    item.MarkComplete();

    Assert.Single(item.DomainEvents);
    Assert.IsType<ToDoItemCompletedEvent>(item.DomainEvents.First());
  }
}

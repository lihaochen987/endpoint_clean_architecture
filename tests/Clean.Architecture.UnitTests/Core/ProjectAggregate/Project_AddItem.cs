namespace Clean.Architecture.UnitTests.Core.ProjectAggregate;

using Clean.Architecture.Core.ProjectAggregate;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
public class Project_AddItem
{
  /// <summary>
  /// TODO.
  /// </summary>
  private Project testProject = new Project("some name", PriorityStatus.Backlog);

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void AddsItemToItems()
  {
    var testItem = new ToDoItem { Title = "title", Description = "description" };

    testProject.AddItem(testItem);

    Assert.Contains(testItem, testProject.Items);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void ThrowsExceptionGivenNullItem()
  {
#nullable disable
    Action action = () => testProject.AddItem(null);
#nullable enable

    var ex = Assert.Throws<ArgumentNullException>(action);
    Assert.Equal("newItem", ex.ParamName);
  }
}

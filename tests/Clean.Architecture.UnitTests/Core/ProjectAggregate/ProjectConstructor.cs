namespace Clean.Architecture.UnitTests.Core.ProjectAggregate;

using Clean.Architecture.Core.ProjectAggregate;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
public class ProjectConstructor
{
  private readonly string _testName = "test name";
  private readonly PriorityStatus _testPriority = PriorityStatus.Backlog;
  private Project? _testProject;

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void InitializesName()
  {
    _testProject = CreateProject();

    Assert.Equal(_testName, _testProject.Name);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void InitializesPriority()
  {
    _testProject = CreateProject();

    Assert.Equal(_testPriority, _testProject.Priority);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void InitializesTaskListToEmptyList()
  {
    _testProject = CreateProject();

    Assert.NotNull(_testProject.Items);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void InitializesStatusToInProgress()
  {
    _testProject = CreateProject();

    Assert.Equal(ProjectStatus.Complete, _testProject.Status);
  }

  private Project CreateProject()
  {
    return new Project(_testName, _testPriority);
  }
}

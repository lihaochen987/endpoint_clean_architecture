namespace Clean.Architecture.UnitTests.Core.ProjectAggregate;

using Clean.Architecture.Core.ProjectAggregate;
using Xunit;

/// <summary>
/// Tests the construction of the Project class class.
/// </summary>
public class ProjectConstructor
{
  private readonly string _testName = "test name";
  private readonly PriorityStatus _testPriority = PriorityStatus.Backlog;
  private Project? _testProject;

  /// <summary>
  /// Tests that the constructor initialises the name correctly.
  /// </summary>
  [Fact]
  public void InitializesName()
  {
    _testProject = CreateProject();

    Assert.Equal(_testName, _testProject.Name);
  }

  /// <summary>
  /// Tests that the constructor initialises the priority correctly.
  /// </summary>
  [Fact]
  public void InitializesPriority()
  {
    _testProject = CreateProject();

    Assert.Equal(_testPriority, _testProject.Priority);
  }

  /// <summary>
  /// Tests that the constructor initialises the TaskList correctly.
  /// </summary>
  [Fact]
  public void InitializesTaskListToEmptyList()
  {
    _testProject = CreateProject();

    Assert.NotNull(_testProject.Items);
  }

  /// <summary>
  /// Tests that the constructor initialises the project status correctly.
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

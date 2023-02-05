namespace Clean.Architecture.UnitTests.Core.ProjectAggregate.Project;

using Clean.Architecture.Core.ProjectAggregate;
using Shouldly;
using Xunit;

/// <summary>
/// Tests the UpdateName method of the Contributor.
/// </summary>
public class ProjectUpdateName
{
  /// <summary>
  /// Whether the Name is successfully updated.
  /// </summary>
  [Fact]
  public void NameSuccessfullyUpdated()
  {
    // Arrange
    var project = new Project("TestProjectName1", PriorityStatus.Critical);

    // Act
    project.UpdateName("TestProjectName2");

    // Assert
    project.Name.ShouldBe("TestProjectName2");
  }
}

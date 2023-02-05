namespace Clean.Architecture.UnitTests.Core.ProjectAggregate.Specifications;

using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.Core.ProjectAggregate.Specifications;
using Builders;
using Shouldly;
using Xunit;

/// <summary>
/// Tests getting a Project along with Items by Project Id.
/// </summary>
public class ProjectByIdWithItemsSpecTests
{
  private readonly string _testProjectName = "Correct!";

  /// <summary>
  /// Tests whether a to-do item can successfully be retrieved by string.
  /// </summary>
  [Fact]
  public void SuccessfullyGetsCorrectProjectWithItems()
  {
    // Arrange
    var spec = new ProjectByIdWithItemsSpec(1);

    // Act
    var result = spec.Evaluate(GetProjectById()).FirstOrDefault();

    // Assert
    result.ShouldNotBeNull();
    result.Name.ShouldBe(_testProjectName);
    result.Id.ShouldBe(1);
  }

  private List<Project> GetProjectById()
  {
    var projectOne = new ProjectBuilder().WithDefaultValues().Id(1).Name("Correct!").Build();
    var projectTwo = new ProjectBuilder().WithDefaultValues().Id(2).Build();
    var projectThree = new ProjectBuilder().WithDefaultValues().Id(3).Build();

    return new List<Project> { projectOne, projectTwo, projectThree };
  }
}

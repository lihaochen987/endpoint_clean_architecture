namespace Clean.Architecture.IntegrationTests.Data;

using Core.ProjectAggregate;
using Xunit;
using Shouldly;

/// <summary>
/// TODO.
/// </summary>
public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task AddsProjectAndSetsId()
  {
    // Arrange
    var testProjectName = "testProject";
    var testProjectStatus = PriorityStatus.Backlog;
    var repository = GetRepository();
    var project = new Project(testProjectName, testProjectStatus);

    // Act
    await repository.AddAsync(project);

    // Assert
    var newProject = (await repository.ListAsync())
      .FirstOrDefault();
    testProjectName.ShouldBe(newProject?.Name);
    testProjectStatus.ShouldBe(newProject?.Priority);
    newProject?.Id.ShouldBeGreaterThan(0);
  }
}

namespace Clean.Architecture.IntegrationTests.Data;

using Core.ProjectAggregate;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // Arrange
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var project = new Project(initialName, PriorityStatus.Backlog);
    await repository.AddAsync(project);

    // Act
    await repository.DeleteAsync(project);

    // Assert
    Assert.DoesNotContain(
      await repository.ListAsync(),
      p => p.Name == initialName);
  }
}

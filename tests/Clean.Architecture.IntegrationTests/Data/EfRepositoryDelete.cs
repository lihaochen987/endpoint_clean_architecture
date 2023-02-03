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
    // add a project
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var project = new Project(initialName, PriorityStatus.Backlog);
    await repository.AddAsync(project);

    // delete the item
    await repository.DeleteAsync(project);

    // verify it's no longer there
    Assert.DoesNotContain(
        await repository.ListAsync(),
        project => project.Name == initialName);
  }
}

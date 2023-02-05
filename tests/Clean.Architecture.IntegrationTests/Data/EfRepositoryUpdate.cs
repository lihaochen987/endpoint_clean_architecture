namespace Clean.Architecture.IntegrationTests.Data;

using Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
public class EfRepositoryUpdate : BaseEfRepoTestFixture
{
  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // Arrange
    // add a project
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var project = new Project(initialName, PriorityStatus.Backlog);

    await repository.AddAsync(project);

    // detach the item so we get a different instance
    DbContext.Entry(project).State = EntityState.Detached;

    // fetch the item and update its title
    var newProject = (await repository.ListAsync())
      .FirstOrDefault(project => project.Name == initialName);
    if (newProject == null)
    {
      Assert.NotNull(newProject);
      return;
    }

    Assert.NotSame(project, newProject);
    var newName = Guid.NewGuid().ToString();
    newProject.UpdateName(newName);

    // Act
    await repository.UpdateAsync(newProject);

    // Assert
    var updatedItem = (await repository.ListAsync())
      .FirstOrDefault(project => project.Name == newName);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(project.Name, updatedItem?.Name);
    Assert.Equal(project.Priority, updatedItem?.Priority);
    Assert.Equal(newProject.Id, updatedItem?.Id);
  }
}

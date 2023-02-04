namespace Clean.Architecture.Infrastructure.Data;

using Core.ContributorAggregate;
using Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// TODO.
/// </summary>
public static class AppDbContextSeed
{
  /// <summary>
  /// TODO.
  /// </summary>
  private static readonly Contributor _contributor1 = new ("Ardalis");

  /// <summary>
  /// TODO.
  /// </summary>
  private static readonly Contributor _contributor2 = new ("Snowfrog");

  /// <summary>
  /// TODO.
  /// </summary>
  private static readonly Project _testProject1 = new Project("Test Project", PriorityStatus.Backlog);

  /// <summary>
  /// TODO.
  /// </summary>
  private static readonly ToDoItem _toDoItem1 = new ToDoItem("Get Sample Working", "Try to get the sample to build.");

  /// <summary>
  /// TODO.
  /// </summary>
  private static readonly ToDoItem _toDoItem2 =
    new ToDoItem(
      "Review Solution",
      "Review the different projects in the solution and how they relate to one another.");

  /// <summary>
  /// TODO.
  /// </summary>
  private static readonly ToDoItem _toDoItem3 = new ToDoItem(
    "Run and Review Tests",
    "Make sure all the tests run and review what they are doing.");

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="serviceProvider">TODO LATER.</param>
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using var dbContext = new AppDbContext(
      serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);

    // Look for any to-do items.
    if (dbContext.ToDoItems.Any())
    {
      return; // DB has been seeded
    }

    PopulateTestData(dbContext);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="dbContext">TODO LATER.</param>
  private static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Projects)
    {
      dbContext.Remove(item);
    }

    foreach (var item in dbContext.ToDoItems)
    {
      dbContext.Remove(item);
    }

    foreach (var item in dbContext.Contributors)
    {
      dbContext.Remove(item);
    }

    dbContext.SaveChanges();

    dbContext.Contributors.Add(_contributor1);
    dbContext.Contributors.Add(_contributor2);

    dbContext.SaveChanges();

    _toDoItem1.AddContributor(_contributor1.Id);
    _toDoItem2.AddContributor(_contributor2.Id);
    _toDoItem3.AddContributor(_contributor1.Id);

    _testProject1.AddItem(_toDoItem1);
    _testProject1.AddItem(_toDoItem2);
    _testProject1.AddItem(_toDoItem3);
    dbContext.Projects.Add(_testProject1);

    dbContext.SaveChanges();
  }
}

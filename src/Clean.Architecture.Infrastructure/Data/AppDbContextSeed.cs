namespace Clean.Architecture.Infrastructure.Data;

using Core.ContributorAggregate;
using Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Seeds the initial Database.
/// </summary>
public static class AppDbContextSeed
{
  /// <summary>
  /// A Contributor object.
  /// </summary>
  public static readonly Contributor Contributor1 = new ("Ardalis");

  /// <summary>
  /// A Contributor object.
  /// </summary>
  public static readonly Contributor Contributor2 = new ("Snowfrog");

  /// <summary>
  /// A Project object.
  /// </summary>
  public static readonly Project TestProject1 = new ("Test Project", PriorityStatus.Backlog);

  /// <summary>
  /// A To-do item object.
  /// </summary>
  public static readonly ToDoItem ToDoItem1 = new ("Get Sample Working", "Try to get the sample to build.");

  /// <summary>
  /// A To-do item object.
  /// </summary>
  public static readonly ToDoItem ToDoItem2 =
    new ToDoItem(
      "Review Solution",
      "Review the different projects in the solution and how they relate to one another.");

  /// <summary>
  /// A To-do item object.
  /// </summary>
  public static readonly ToDoItem ToDoItem3 = new (
    "Run and Review Tests",
    "Make sure all the tests run and review what they are doing.");

  /// <summary>
  /// Initialises the Service Provider.
  /// </summary>
  /// <param name="serviceProvider">The Service provider.</param>
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
  /// Method which populates the database.
  /// </summary>
  /// <param name="dbContext">The database context to be populated.</param>
  public static void PopulateTestData(AppDbContext dbContext)
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

    dbContext.Contributors.Add(Contributor1);
    dbContext.Contributors.Add(Contributor2);

    dbContext.SaveChanges();

    ToDoItem1.AddContributor(Contributor1.Id);
    ToDoItem2.AddContributor(Contributor2.Id);
    ToDoItem3.AddContributor(Contributor1.Id);

    TestProject1.AddItem(ToDoItem1);
    TestProject1.AddItem(ToDoItem2);
    TestProject1.AddItem(ToDoItem3);
    dbContext.Projects.Add(TestProject1);

    dbContext.SaveChanges();
  }
}

namespace Clean.Architecture.Infrastructure.Data;

using System.Reflection;
using Core.ContributorAggregate;
using Core.ProjectAggregate;
using SharedKernel;
using SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Defines the database context.
/// </summary>
public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  /// <summary>
  /// Initializes a new instance of the <see cref="AppDbContext"/> class.
  /// </summary>
  /// <param name="options">TODO LATER.</param>
  /// <param name="dispatcher">TODO LATER2.</param>
  public AppDbContext(
    DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
    : base(options)
  {
    _dispatcher = dispatcher;
  }

  /// <summary>
  /// Gets the to-do items from the database.
  /// </summary>
  public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

  /// <summary>
  /// Gets the projects from the database.
  /// </summary>
  public DbSet<Project> Projects => Set<Project>();

  /// <summary>
  /// Gets the contributors from the database.
  /// </summary>
  public DbSet<Contributor> Contributors => Set<Contributor>();

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="cancellationToken">TODO LATER1.</param>
  /// <returns>TODO LATER2.</returns>
  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null)
    {
      return result;
    }

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
      .Select(e => e.Entity)
      .Where(e => e.DomainEvents.Any())
      .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>TODO LATER2.</returns>
  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="modelBuilder">TODO LATER.</param>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}

namespace Clean.Architecture.IntegrationTests.Data;

using Core.ProjectAggregate;
using Clean.Architecture.Infrastructure.Data;
using SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

/// <summary>
/// TODO.
/// </summary>
public abstract class BaseEfRepoTestFixture
{
  /// <summary>
  /// TODO.
  /// </summary>
  protected AppDbContext _dbContext;

  /// <summary>
  /// Initializes a new instance of the <see cref="BaseEfRepoTestFixture"/> class.
  /// </summary>
  protected BaseEfRepoTestFixture()
  {
    var options = CreateNewContextOptions();
    var mockEventDispatcher = new Mock<IDomainEventDispatcher>();

    _dbContext = new AppDbContext(options, mockEventDispatcher.Object);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>TODO LATER.</returns>
  protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
  {
    // Create a fresh service provider, and therefore a fresh
    // InMemory database instance.
    var serviceProvider = new ServiceCollection()
      .AddEntityFrameworkInMemoryDatabase()
      .BuildServiceProvider();

    // Create a new options instance telling the context to use an
    // InMemory database and the new service provider.
    var builder = new DbContextOptionsBuilder<AppDbContext>();
    builder.UseInMemoryDatabase("cleanarchitecture")
      .UseInternalServiceProvider(serviceProvider);

    return builder.Options;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>TODO LATER.</returns>
  protected EfRepository<Project> GetRepository()
  {
    return new EfRepository<Project>(_dbContext);
  }
}

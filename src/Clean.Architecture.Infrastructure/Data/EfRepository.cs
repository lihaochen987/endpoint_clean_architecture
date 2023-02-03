namespace Clean.Architecture.Infrastructure.Data;

using Ardalis.Specification.EntityFrameworkCore;
using SharedKernel.Interfaces;

/// <summary>
/// TODO.
/// </summary>
/// <typeparam name="T">TODO LATER.</typeparam>
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
  /// <summary>
  /// Initializes a new instance of the <see cref="EfRepository{T}"/> class.
  /// </summary>
  /// <param name="dbContext">TODO.</param>
  public EfRepository(AppDbContext dbContext)
        : base(dbContext)
  {
  }
}

namespace Clean.Architecture.SharedKernel.Interfaces;
using Ardalis.Specification;

/// <summary>
/// Specifies that the Repository is read-only.
/// </summary>
/// <typeparam name="T">The DbContext relating to that Repository.</typeparam>
public interface IReadRepository<T> : IReadRepositoryBase<T>
    where T : class, IAggregateRoot
{
}

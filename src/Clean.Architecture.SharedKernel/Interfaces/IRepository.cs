namespace Clean.Architecture.SharedKernel.Interfaces;
using Ardalis.Specification;

/// <summary>
/// Specifies a Repository which can be read and written to.
/// </summary>
/// <typeparam name="T">The DbContext relating to that Repository.</typeparam>
public interface IRepository<T> : IRepositoryBase<T>
    where T : class, IAggregateRoot
{
}

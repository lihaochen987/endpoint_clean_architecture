namespace Clean.Architecture.SharedKernel.Interfaces;

/// <summary>
/// The cluster of domain objects to be treated as a single unit.
/// Apply this marker interface only to aggregate root entities
/// Repositories will only work with aggregate roots, not their children
/// </summary>
public interface IAggregateRoot
{
}

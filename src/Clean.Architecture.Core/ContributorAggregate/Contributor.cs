namespace Clean.Architecture.Core.ContributorAggregate;

using Ardalis.GuardClauses;
using SharedKernel;
using Clean.Architecture.SharedKernel.Interfaces;

/// <summary>
/// The Contributor Domain Model Object.
/// </summary>
public class Contributor : EntityBase, IAggregateRoot
{
  /// <summary>
  /// Initializes a new instance of the <see cref="Contributor"/> class.
  /// </summary>
  /// <param name="name">The Name of the contributor.</param>
  public Contributor(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }

  /// <summary>
  /// Gets the Name of the Contributor.
  /// </summary>
  public string Name { get; private set; }

  /// <summary>
  /// Updates the Name of the contributor.
  /// </summary>
  /// <param name="newName">The new Name of the contributor.</param>
  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}

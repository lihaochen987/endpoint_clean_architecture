namespace Clean.Architecture.UnitTests.Builders;

using Clean.Architecture.Core.ContributorAggregate;

/// <summary>
/// The builder responsible for instantiating a Contributor object.
/// </summary>
public class ContributorBuilder
{
  private readonly Contributor _contributor = new ("test");

  /// <summary>
  /// Sets the Id of the ContributorBuilder.
  /// </summary>
  /// <param name="id">The id.</param>
  /// <returns>The ContributorBuilder.</returns>
  public ContributorBuilder Id(int id)
  {
    _contributor.Id = id;
    return this;
  }

  /// <summary>
  /// Sets the name of the ContributorBuilder.
  /// </summary>
  /// <param name="name">The name.</param>
  /// <returns>The ContributorBuilder.</returns>
  public ContributorBuilder Name(string name)
  {
    _contributor.UpdateName(name);
    return this;
  }

  /// <summary>
  /// Initialises the default values of the ContributorBuilder.
  /// </summary>
  /// <returns>The ContributorBuilder.</returns>
  public ContributorBuilder WithDefaultValues()
  {
    _contributor.Id = 1;
    _contributor.UpdateName("TestName");
    return this;
  }

  /// <summary>
  /// Builds the Contributor object.
  /// </summary>
  /// <returns>The Contributor object.</returns>
  public Contributor Build() => _contributor;
}

namespace Clean.Architecture.UnitTests.Core.ContributorAggregate;

using Clean.Architecture.Core.ContributorAggregate;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
public class ContributorConstructor
{
  /// <summary>
  /// TODO.
  /// </summary>
  private readonly string _testName = "test name";

  /// <summary>
  /// TODO.
  /// </summary>
  private Contributor? _testContributor;

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void InitializesName()
  {
    _testContributor = CreateContributor();

    Assert.Equal(_testName, _testContributor.Name);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>TODO LATER.</returns>
  private Contributor CreateContributor()
  {
    return new Contributor(_testName);
  }
}

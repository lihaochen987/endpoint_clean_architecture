namespace Clean.Architecture.UnitTests.Core.ContributorAggregate;

using Clean.Architecture.Core.ContributorAggregate;
using Xunit;

/// <summary>
/// Tests the construction of the Contributor class.
/// </summary>
public class ContributorConstructor
{
  private readonly string _testName = "test name";

  private Contributor? _testContributor;

  /// <summary>
  /// Tests that the constructor initialises the name correctly.
  /// </summary>
  [Fact]
  public void InitializesName()
  {
    _testContributor = CreateContributor();

    Assert.Equal(_testName, _testContributor.Name);
  }

  /// <summary>
  /// Initialises the Contributor object.
  /// </summary>
  /// <returns>The Contributor object.</returns>
  private Contributor CreateContributor()
  {
    return new Contributor(_testName);
  }
}

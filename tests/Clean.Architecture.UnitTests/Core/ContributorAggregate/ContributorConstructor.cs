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
  private readonly string testName = "test name";

  /// <summary>
  /// TODO.
  /// </summary>
  private Contributor? testContributor;

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>TODO LATER.</returns>
  private Contributor CreateContributor()
  {
    return new Contributor(testName);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  [Fact]
  public void InitializesName()
  {
    testContributor = CreateContributor();

    Assert.Equal(testName, testContributor.Name);
  }
}

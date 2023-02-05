namespace Clean.Architecture.UnitTests.Core.ContributorAggregate;

using Clean.Architecture.Core.ContributorAggregate;
using Shouldly;
using Xunit;

/// <summary>
/// Tests the Contributor domain object.
/// </summary>
public class ContributorTests
{
  /// <summary>
  /// Whether the Name is successfully updated.
  /// </summary>
  [Fact]
  public void NameSuccessfullyUpdated()
  {
    // Arrange
    var contributor = new Contributor("TestName1");

    // Act
    contributor.UpdateName("TestName2");

    // Assert
    contributor.Name.ShouldBe("TestName2");
  }
}

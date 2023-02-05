namespace Clean.Architecture.UnitTests.Core.ContributorAggregate.Contributor;

using Shouldly;
using Xunit;

/// <summary>
/// Tests the UpdateName method of the Contributor.
/// </summary>
public class ContributorUpdateNameTests
{
  /// <summary>
  /// Whether the Name is successfully updated.
  /// </summary>
  [Fact]
  public void NameSuccessfullyUpdated()
  {
    // Arrange
    var contributor = new Architecture.Core.ContributorAggregate.Contributor("TestName1");

    // Act
    contributor.UpdateName("TestName2");

    // Assert
    contributor.Name.ShouldBe("TestName2");
  }
}

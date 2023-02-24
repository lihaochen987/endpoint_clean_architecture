namespace Clean.Architecture.ApiTests.ContributorEndpoints;

using Ardalis.HttpClientTestExtensions;
using Infrastructure.Data;
using Web;
using Clean.Architecture.Web.ContributorEndpoints;
using Xunit;
using Shouldly;

/// <summary>
/// Tests relating to the GetContributorById endpoint.
/// </summary>
[Collection("Sequential")]
public class GetContributorByIdTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="GetContributorByIdTests"/> class.
  /// </summary>
  /// <param name="factory">The client used for testing purposes.</param>
  public GetContributorByIdTests(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// Ensures that the previously seeded Contributor is successfully retrieved.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ExistingContributorIsRetrieved()
  {
    // Arrange
    const int seededId = 1;

    // Act
    var result =
      await _client.GetAndDeserializeAsync<ContributorRecord>(GetContributorByIdRequest.BuildRoute(seededId));

    // Assert
    result.id.ShouldBe(1);
    result.name.ShouldBe(AppDbContextSeed.Contributor1.Name);
  }

  /// <summary>
  /// Ensures an invalid Contributor is not found.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task NonExistingContributorReturnsBadRequest()
  {
    // Arrange
    const int invalidSeedId = 0;

    // Act
    string route = GetContributorByIdRequest.BuildRoute(invalidSeedId);

    // Assert
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}

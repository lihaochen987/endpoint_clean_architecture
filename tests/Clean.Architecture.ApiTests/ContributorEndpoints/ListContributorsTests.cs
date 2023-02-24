namespace Clean.Architecture.ApiTests.ContributorEndpoints;

using Clean.Architecture.Web.ContributorEndpoints;
using Ardalis.HttpClientTestExtensions;
using Web;
using Xunit;
using Infrastructure.Data;
using Shouldly;

/// <summary>
/// Tests relating to the ListContributors endpoint.
/// </summary>
[Collection("Sequential")]
public class ListContributorsTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="ListContributorsTests"/> class.
  /// </summary>
  /// <param name="factory">The client used for testing purposes.</param>
  public ListContributorsTests(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// Ensures Contributors are returned from the seeded database.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task AllContributorsAreListed()
  {
    // Act
    var result = await _client.GetAndDeserializeAsync<ContributorListResponse>("/Contributors");

    // Assert
    result.Contributors.Count.ShouldBe(2);
    result.Contributors.ShouldContain(i => i.name == AppDbContextSeed.Contributor1.Name);
    result.Contributors.ShouldContain(i => i.name == AppDbContextSeed.Contributor2.Name);
  }
}

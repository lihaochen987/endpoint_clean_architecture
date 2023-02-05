namespace Clean.Architecture.ApiTests.ContributorEndpoints;

using Ardalis.HttpClientTestExtensions;
using Infrastructure.Data;
using Web;
using Clean.Architecture.Web.ContributorEndpoints;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
[Collection("Sequential")]
public class ContributorGetByIdTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="ContributorGetByIdTests"/> class.
  /// </summary>
  /// <param name="factory">TODO.</param>
  public ContributorGetByIdTests(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ReturnsSeedContributorGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<ContributorRecord>(GetContributorByIdRequest.BuildRoute(1));

    Assert.Equal(1, result.id);
    Assert.Equal(AppDbContextSeed.Contributor1.Name, result.name);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ReturnsNotFoundGivenId0()
  {
    string route = GetContributorByIdRequest.BuildRoute(0);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}

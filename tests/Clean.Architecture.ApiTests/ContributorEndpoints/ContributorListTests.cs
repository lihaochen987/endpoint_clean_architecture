namespace Clean.Architecture.ApiTests.ContributorEndpoints;

using Clean.Architecture.Web.ContributorEndpoints;
using Ardalis.HttpClientTestExtensions;
using Web;
using Xunit;
using Infrastructure.Data;

/// <summary>
/// TODO.
/// </summary>
[Collection("Sequential")]
public class ContributorListTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="ContributorListTests"/> class.
  /// </summary>
  /// <param name="factory">TODO.</param>
  public ContributorListTests(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ReturnsTwoContributors()
  {
    var result = await _client.GetAndDeserializeAsync<ContributorListResponse>("/Contributors");

    Assert.Equal(2, result.Contributors.Count);
    Assert.Contains(result.Contributors, i => i.name == AppDbContextSeed.Contributor1.Name);
    Assert.Contains(result.Contributors, i => i.name == AppDbContextSeed.Contributor2.Name);
  }
}

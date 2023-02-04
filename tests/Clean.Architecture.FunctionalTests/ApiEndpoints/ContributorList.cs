namespace Clean.Architecture.FunctionalTests.ApiEndpoints;

using Web.ContributorEndpoints;
using Ardalis.HttpClientTestExtensions;
using Web;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
[Collection("Sequential")]
public class ContributorList : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="ContributorList"/> class.
  /// </summary>
  /// <param name="factory">TODO LATER.</param>
  public ContributorList(CustomWebApplicationFactory<WebMarker> factory)
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
    Assert.Contains(result.Contributors, i => i.name == SeedData.Contributor1.Name);
    Assert.Contains(result.Contributors, i => i.name == SeedData.Contributor2.Name);
  }
}

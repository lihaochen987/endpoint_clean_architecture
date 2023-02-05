namespace Clean.Architecture.ApiTests.ContributorEndpoints;

using Clean.Architecture.Web.ContributorEndpoints;
using Ardalis.HttpClientTestExtensions;
using Web;
using Xunit;
using Infrastructure.Data;
using Shouldly;

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
    // Act
    var result = await _client.GetAndDeserializeAsync<ContributorListResponse>("/Contributors");

    // Assert
    result.Contributors.Count.ShouldBe(2);
    result.Contributors.ShouldContain(i => i.name == AppDbContextSeed.Contributor1.Name);
    result.Contributors.ShouldContain(i => i.name == AppDbContextSeed.Contributor2.Name);
  }
}

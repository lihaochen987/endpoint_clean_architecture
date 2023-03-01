namespace Clean.Architecture.ApiTests.ContributorEndpoints;

using Clean.Architecture.Web.ContributorEndpoints;
using System.Net;
using FastEndpoints;
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
    var (response, result) = await _client.GETAsync<ListContributors, ContributorListResponse>();

    // Assert
    response.ShouldNotBeNull();
    response.StatusCode.ShouldBe(HttpStatusCode.OK);
    result?.Contributors.Count.ShouldBe(2);
    result?.Contributors.ShouldContain(i => i.contributorName == AppDbContextSeed.Contributor1.Name);
    result?.Contributors.ShouldContain(i => i.contributorName == AppDbContextSeed.Contributor2.Name);
  }
}

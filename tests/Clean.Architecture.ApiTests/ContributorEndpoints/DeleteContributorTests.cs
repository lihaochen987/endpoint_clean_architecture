namespace Clean.Architecture.ApiTests.ContributorEndpoints;

using Xunit;
using Web;
using Microsoft.AspNetCore.Mvc.Testing;

/// <summary>
/// Tests relating to the DeleteContributor endpoint.
/// </summary>
[Collection("Sequential")]
public class DeleteContributorTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="DeleteContributorTests"/> class.
  /// </summary>
  /// <param name="factory">The client used for testing purposes.</param>
  public DeleteContributorTests(WebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }
}

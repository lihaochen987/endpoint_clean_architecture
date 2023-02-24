namespace Clean.Architecture.ApiTests.ContributorEndpoints;

using Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

/// <summary>
/// Tests relating to the UpdateContributor endpoint.
/// </summary>
[Collection("Sequential")]
public class UpdateContributorTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="UpdateContributorTests"/> class.
  /// </summary>
  /// <param name="factory">The client used for testing purposes.</param>
  public UpdateContributorTests(WebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }
}

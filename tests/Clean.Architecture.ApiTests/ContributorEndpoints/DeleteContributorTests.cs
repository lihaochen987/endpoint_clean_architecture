namespace Clean.Architecture.ApiTests.ContributorEndpoints;

using Xunit;
using Web;
using System.Net;
using Clean.Architecture.Web.ContributorEndpoints;
using FastEndpoints;
using Shouldly;

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
  public DeleteContributorTests(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// Ensures that existing Contributor is successfully deleted.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task DeleteValidContributorSucceeds()
  {
    // Arrange
    var request = new DeleteContributorRequest { ContributorId = 1 };

    // Act
    var response =
      await _client.DELETEAsync<DeleteContributor, DeleteContributorRequest>(request);

    // Assert
    response.ShouldNotBeNull();
    response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
  }

  /// <summary>
  /// Ensures NotFound error code if Contributor doesn't exist in database.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task DeleteNonExistingContributorReturnsNotFound()
  {
    // Arrange
    var request = new DeleteContributorRequest { ContributorId = 0 };

    // Act
    var response = await _client.DELETEAsync<DeleteContributor, DeleteContributorRequest>(request);

    // Assert
    response.ShouldNotBeNull();
    response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
  }
}

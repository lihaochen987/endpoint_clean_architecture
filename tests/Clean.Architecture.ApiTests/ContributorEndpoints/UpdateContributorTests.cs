namespace Clean.Architecture.ApiTests.ContributorEndpoints;

using Web;
using Xunit;
using System.Net;
using Clean.Architecture.Web.ContributorEndpoints;
using FastEndpoints;
using Shouldly;

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
  public UpdateContributorTests(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// Ensures that a Contributor in the database is successfully updated.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ValidContributorIsUpdated()
  {
    // Arrange
    var request = new UpdateContributorRequest { Id = 1, Name = "New Ardalis" };

    // Act
    var (response, result) =
      await _client.PUTAsync<UpdateContributor, UpdateContributorRequest, UpdateContributorResponse>(request);

    // Assert
    response.ShouldNotBeNull();
    response.StatusCode.ShouldBe(HttpStatusCode.OK);
    result?.Contributor?.contributorId.ShouldBe(1);
    result?.Contributor?.contributorName.ShouldBe("New Ardalis");
  }

  /// <summary>
  /// Ensures that a request with no name returns a Bad Request response.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task NoNameReturnsBadRequest()
  {
    // Arrange
    var request = new UpdateContributorRequest { Id = 1 };

    // Act
    var (response, _) =
      await _client.PUTAsync<UpdateContributor, UpdateContributorRequest, UpdateContributorResponse>(request);

    // Assert
    response.ShouldNotBeNull();
    response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
  }

  // /// <summary>
  // /// Uncomment and fix.
  // /// </summary>
  // /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  // [Fact]
  // public async Task NonExistingContributorReturnsNotFound()
  // {
  //   // Arrange
  //   var request = new UpdateContributorRequest { Id = 0, Name = "Doesnt Exist" };
  //
  //   // Act
  //   var (response, _) =
  //     await _client.PUTAsync<UpdateContributor, UpdateContributorRequest, UpdateContributorResponse>(request);
  //
  //   // Assert
  //   response.ShouldNotBeNull();
  //   response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
  // }
}

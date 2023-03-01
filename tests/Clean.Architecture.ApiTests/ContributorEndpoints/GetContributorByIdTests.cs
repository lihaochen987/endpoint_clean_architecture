namespace Clean.Architecture.ApiTests.ContributorEndpoints;

using Infrastructure.Data;
using Web;
using Clean.Architecture.Web.ContributorEndpoints;
using Xunit;
using Shouldly;
using FastEndpoints;
using System.Net;

/// <summary>
/// Tests relating to the GetContributorById endpoint.
/// </summary>
[Collection("Sequential")]
public class GetContributorByIdTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="GetContributorByIdTests"/> class.
  /// </summary>
  /// <param name="factory">The client used for testing purposes.</param>
  public GetContributorByIdTests(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// Ensures that the previously seeded Contributor is successfully retrieved.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ExistingContributorIsRetrieved()
  {
    // Arrange
    var request = new GetContributorByIdRequest { ContributorId = 1 };

    // Act
    var (response, result) =
      await _client.GETAsync<GetContributorById, GetContributorByIdRequest, ContributorRecord>(request);

    // Assert
    response.ShouldNotBeNull();
    response.StatusCode.ShouldBe(HttpStatusCode.OK);
    result?.contributorId.ShouldBe(1);
    result?.contributorName.ShouldBe(AppDbContextSeed.Contributor1.Name);
  }

  // /// <summary>
  // /// Ensures an invalid Contributor is not found.
  // /// </summary>
  // /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  // [Fact]
  // public async Task NonExistingContributorReturnsBadRequest()
  // {
  //   // Arrange
  //   var request = new GetContributorByIdRequest { ContributorId = 0 };
  //
  //   // Act
  //   var (response, result) =
  //     await _client.GETAsync<GetContributorById, GetContributorByIdRequest, ContributorRecord>(request);
  //
  //   // Assert
  //   response.ShouldNotBeNull();
  //   response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
  //   result?.contributorId.ShouldBe(1);
  // }
}

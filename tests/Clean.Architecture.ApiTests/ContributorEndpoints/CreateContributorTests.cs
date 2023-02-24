namespace Clean.Architecture.ApiTests.ContributorEndpoints;

using Web;
using Clean.Architecture.Web.ContributorEndpoints;
using Xunit;
using FastEndpoints;
using Shouldly;
using System.Net;

/// <summary>
/// Tests relating to the CreateContributor endpoint.
/// </summary>
[Collection("Sequential")]
public class CreateContributorTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="CreateContributorTests"/> class.
  /// </summary>
  /// <param name="factory">The client used for testing purposes.</param>
  public CreateContributorTests(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// Ensures a valid ContributorRequest is persisted.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
  [Fact]
  public async Task CreatesAndPersistsInDatabase()
  {
    // Arrange
    var request = new CreateContributorRequest { Name = "HaoChen Li" };

    // Act
    var (response, result) =
      await _client.POSTAsync<CreateContributor, CreateContributorRequest, CreateContributorResponse>(request);

    // Assert
    response.ShouldNotBeNull();
    response.StatusCode.ShouldBe(HttpStatusCode.OK);
    result?.Name.ShouldBe("HaoChen Li");
  }

  /// <summary>
  /// Ensures a null value Contributor returns a bad request status.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task NullNameThrowsError()
  {
    // Arrange
    var request = new CreateContributorRequest { Name = null };

    // Act
    var (response, result) =
      await _client.POSTAsync<CreateContributor, CreateContributorRequest, CreateContributorResponse>(request);

    // Assert
    response.ShouldNotBeNull();
    response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    result?.Name.ShouldBeNull();
  }
}

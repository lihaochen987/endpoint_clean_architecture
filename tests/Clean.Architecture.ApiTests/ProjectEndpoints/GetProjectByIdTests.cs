namespace Clean.Architecture.ApiTests.ProjectEndpoints;

using Infrastructure.Data;
using Web;
using Clean.Architecture.Web.ProjectEndpoints;
using Xunit;
using System.Net;
using Shouldly;
using FastEndpoints;

/// <summary>
/// Tests relating the to ProjectGetById endpoint.
/// </summary>
[Collection("Sequential")]
public class GetProjectByIdTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="GetProjectByIdTests"/> class.
  /// </summary>
  /// <param name="factory">The client used for testing purposes.</param>
  public GetProjectByIdTests(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// Ensures non-existent project returns NotFound status code.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ReturnsNotFoundGivenId0()
  {
    // Arrange
    var request = new GetProjectByIdRequest { ProjectId = 0 };

    // Act
    var response =
      await _client.GETAsync<GetProjectById, GetProjectByIdRequest>(request);

    // Assert
    response.ShouldNotBeNull();
    response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
  }

  /// <summary>
  /// Ensures that the previously seeded Project is successfully retrieved.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ExistingProjectIsRetrieved()
  {
    // Arrange
    var request = new GetProjectByIdRequest { ProjectId = 1 };

    // Act
    var (response, result) =
      await _client.GETAsync<GetProjectById, GetProjectByIdRequest, GetProjectByIdResponse>(request);

    // Assert
    response.ShouldNotBeNull();
    response.StatusCode.ShouldBe(HttpStatusCode.OK);
    result?.Id.ShouldBe(1);
    result?.Name.ShouldBe(AppDbContextSeed.TestProject1.Name);
    result?.Items.Count.ShouldBe(3);
  }
}

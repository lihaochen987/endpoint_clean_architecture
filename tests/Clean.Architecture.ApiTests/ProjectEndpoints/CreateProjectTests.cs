namespace Clean.Architecture.ApiTests.ProjectEndpoints;

using Web;
using Xunit;
using System.Net;
using Clean.Architecture.Web.ProjectEndpoints;
using FastEndpoints;
using Shouldly;

/// <summary>
/// Tests relating to the CreateProject endpoint.
/// </summary>
public class CreateProjectTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="CreateProjectTests"/> class.
  /// </summary>
  /// <param name="factory">The client used for testing purposes.</param>
  public CreateProjectTests(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// Ensures that a Project with a null name returns a bad request.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ProjectWithNoNameReturnsBadRequest()
  {
    // Arrange
    var request = new CreateProjectRequest();

    // Act
    var response = await _client.POSTAsync<CreateProject, CreateProjectRequest>(request);

    // Assert
    response.ShouldNotBeNull();
    response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
  }

  /// <summary>
  /// Ensures a valid Project is created and persisted.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ValidProjectIsCreatedAndPersisted()
  {
    // Arrange
    var request = new CreateProjectRequest { Name = "Hao Project" };

    // Act
    var (response, result) = await _client.POSTAsync<CreateProject, CreateProjectRequest, CreateProjectResponse>(request);

    // Assert
    response.ShouldNotBeNull();
    response.StatusCode.ShouldBe(HttpStatusCode.OK);
    result?.Name.ShouldBe("Hao Project");
  }
}

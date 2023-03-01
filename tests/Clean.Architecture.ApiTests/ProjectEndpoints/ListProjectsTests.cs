namespace Clean.Architecture.ApiTests.ProjectEndpoints;

using Ardalis.HttpClientTestExtensions;
using Web;
using Xunit;
using Infrastructure.Data;
using Clean.Architecture.Web.ProjectEndpoints;
using Shouldly;

/// <summary>
/// Tests relating to the ListProjects endpoint.
/// </summary>
[Collection("Sequential")]
public class ListProjectsTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="ListProjectsTests"/> class.
  /// </summary>
  /// <param name="factory">The client used for testing purposes.</param>
  public ListProjectsTests(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// Ensures existing projects are returned.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ReturnsProjects()
  {
    // Act
    var result = await _client.GetAndDeserializeAsync<ProjectListResponse>("/Projects");

    // Assert
    result.Projects.Count.ShouldBe(1);
    result.Projects.ShouldContain(new ProjectRecord(AppDbContextSeed.TestProject1.Id, AppDbContextSeed.TestProject1.Name));
  }
}

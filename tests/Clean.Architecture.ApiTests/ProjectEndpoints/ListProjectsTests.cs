namespace Clean.Architecture.ApiTests.ProjectEndpoints;

using Ardalis.HttpClientTestExtensions;
using Web;
using Xunit;
using Infrastructure.Data;
using Clean.Architecture.Web.ProjectEndpoints;

/// <summary>
/// TODO.
/// </summary>
[Collection("Sequential")]
public class ListProjectsTests : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="ListProjectsTests"/> class.
  /// </summary>
  /// <param name="factory">TODO.</param>
  public ListProjectsTests(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ReturnsOneProject()
  {
    var result = await _client.GetAndDeserializeAsync<ProjectListResponse>("/Projects");

    Assert.Single(result.Projects);
    Assert.Contains(result.Projects, i => i.projectName == AppDbContextSeed.TestProject1.Name);
  }
}

namespace Clean.Architecture.ApiTests.ProjectEndpoints;

using Ardalis.HttpClientTestExtensions;
using Infrastructure.Data;
using Web;
using Clean.Architecture.Web.ProjectEndpoints;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
[Collection("Sequential")]
public class ProjectGetById : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="ProjectGetById"/> class.
  /// </summary>
  /// <param name="factory">TODO.</param>
  public ProjectGetById(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ReturnsSeedProjectGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<GetProjectByIdResponse>(GetProjectByIdRequest.BuildRoute(1));

    Assert.Equal(1, result.Id);
    Assert.Equal(AppDbContextSeed.TestProject1.Name, result.Name);
    Assert.Equal(3, result.Items.Count);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ReturnsNotFoundGivenId0()
  {
    string route = GetProjectByIdRequest.BuildRoute(0);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}

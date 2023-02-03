namespace Clean.Architecture.FunctionalTests.ControllerApis;

using Ardalis.HttpClientTestExtensions;
using Web;
using Web.ApiModels;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
[Collection("Sequential")]
public class ProjectCreate : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="ProjectCreate"/> class.
  /// </summary>
  /// <param name="factory">TODO LATER.</param>
  public ProjectCreate(CustomWebApplicationFactory<WebMarker> factory)
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
    var result = await _client.GetAndDeserializeAsync<IEnumerable<ProjectDTO>>("/api/projects");

    IEnumerable<ProjectDTO> projectDtos = result.ToList();

    Assert.Single(projectDtos);
    Assert.Contains(projectDtos, i => i.Name == SeedData.TestProject1.Name);
  }
}

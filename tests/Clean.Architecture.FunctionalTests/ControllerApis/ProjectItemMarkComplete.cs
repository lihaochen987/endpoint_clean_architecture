namespace Clean.Architecture.FunctionalTests.ControllerApis;

using System.Text;
using Web;
using Newtonsoft.Json;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
[Collection("Sequential")]
public class ProjectItemMarkComplete : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="ProjectItemMarkComplete"/> class.
  /// </summary>
  /// <param name="factory">TODO LATER.</param>
  public ProjectItemMarkComplete(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task MarksIncompleteItemComplete()
  {
    int projectId = 1;
    int itemId = 1;

    var jsonContent = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json");

    var response = await _client.PatchAsync($"api/projects/{projectId}/complete/{itemId}", jsonContent);
    response.EnsureSuccessStatusCode();

    var stringResponse = await response.Content.ReadAsStringAsync();
    Assert.Equal(string.Empty, stringResponse);
  }
}

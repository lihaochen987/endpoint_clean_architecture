namespace Clean.Architecture.FunctionalTests.ControllerViews;

using Web;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
[Collection("Sequential")]
public class HomeControllerIndex : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="HomeControllerIndex"/> class.
  /// </summary>
  /// <param name="factory">TODO LATER.</param>
  public HomeControllerIndex(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ReturnsViewWithCorrectMessage()
  {
    HttpResponseMessage response = await _client.GetAsync("/");
    response.EnsureSuccessStatusCode();
    string stringResponse = await response.Content.ReadAsStringAsync();

    Assert.Contains("Clean.Architecture.Web", stringResponse);
  }
}

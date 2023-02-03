namespace Clean.Architecture.FunctionalTests.ControllerApis;

using Web;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
[Collection("Sequential")]
public class MetaControllerInfo : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="MetaControllerInfo"/> class.
  /// </summary>
  /// <param name="factory">TODO LATER.</param>
  public MetaControllerInfo(CustomWebApplicationFactory<WebMarker> factory)
  {
    _client = factory.CreateClient();
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ReturnsVersionAndLastUpdateDate()
  {
    var response = await _client.GetAsync("/info");
    response.EnsureSuccessStatusCode();
    var stringResponse = await response.Content.ReadAsStringAsync();

    Assert.Contains("Version", stringResponse);
    Assert.Contains("Last Updated", stringResponse);
  }
}

﻿namespace Clean.Architecture.FunctionalTests.ApiEndpoints;

using Ardalis.HttpClientTestExtensions;
using Web;
using Web.Endpoints.ProjectEndpoints;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
[Collection("Sequential")]
public class ProjectList : IClassFixture<CustomWebApplicationFactory<WebMarker>>
{
  private readonly HttpClient _client;

  /// <summary>
  /// Initializes a new instance of the <see cref="ProjectList"/> class.
  /// </summary>
  /// <param name="factory">TODO LATER.</param>
  public ProjectList(CustomWebApplicationFactory<WebMarker> factory)
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
    Assert.Contains(result.Projects, i => i.Name == SeedData.TestProject1.Name);
  }
}

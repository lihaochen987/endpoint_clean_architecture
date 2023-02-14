namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// The shared response class of ContributorEndpoints.
/// </summary>
/// <param name="id">The Id of the contributor.</param>
/// <param name="name">The name of the contributor.</param>
public record ContributorRecord(int id, string name);

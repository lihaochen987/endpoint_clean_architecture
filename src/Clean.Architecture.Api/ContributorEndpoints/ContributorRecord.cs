namespace Clean.Architecture.Web.ContributorEndpoints;

/// <summary>
/// The shared response class of ContributorEndpoints.
/// </summary>
/// <param name="contributorId">The Id of the contributor.</param>
/// <param name="contributorName">The name of the contributor.</param>
public record ContributorRecord(int contributorId, string contributorName);

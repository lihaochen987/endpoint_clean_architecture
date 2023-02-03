namespace Clean.Architecture.Core.Interfaces;

using Ardalis.Result;

/// <summary>
/// The Interface of the DeleteContributorService.
/// </summary>
public interface IDeleteContributorService
{
  /// <summary>
  /// The method responsible for deleting the Contributor.
  /// </summary>
  /// <param name="contributorId">The Id of the Contributor being deleted.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  public Task<Result> DeleteContributor(int contributorId);
}

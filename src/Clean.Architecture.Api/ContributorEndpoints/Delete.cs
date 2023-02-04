namespace Clean.Architecture.Web.ContributorEndpoints;

using Ardalis.Result;
using Core.Interfaces;
using FastEndpoints;

/// <summary>
/// TODO.
/// </summary>
public class Delete : Endpoint<DeleteContributorRequest>
{
  private readonly IDeleteContributorService _deleteContributorService;

  /// <summary>
  /// Initializes a new instance of the <see cref="Delete"/> class.
  /// </summary>
  /// <param name="service">TODO LATER.</param>
  public Delete(IDeleteContributorService service)
  {
    _deleteContributorService = service;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  public override void Configure()
  {
    Delete(DeleteContributorRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("ContributorEndpoints"));
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="request">TODO LATER.</param>
  /// <param name="cancellationToken">TODO LATER2.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  public override async Task HandleAsync(
    DeleteContributorRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _deleteContributorService.DeleteContributor(request.ContributorId);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    await SendNoContentAsync(cancellationToken);
  }
}

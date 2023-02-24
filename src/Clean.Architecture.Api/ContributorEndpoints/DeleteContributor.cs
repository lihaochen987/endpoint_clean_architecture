namespace Clean.Architecture.Web.ContributorEndpoints;

using Ardalis.Result;
using Core.Interfaces;
using FastEndpoints;

/// <summary>
/// The Contributor Delete endpoint.
/// </summary>
public class Delete : Endpoint<DeleteContributorRequest>
{
  private readonly IDeleteContributorService _deleteContributorService;

  /// <summary>
  /// Initializes a new instance of the <see cref="Delete"/> class.
  /// </summary>
  /// <param name="service">The DeleteContributorService.</param>
  public Delete(IDeleteContributorService service)
  {
    _deleteContributorService = service;
  }

  /// <summary>
  /// Overrides the FastApi Configure method and sets the route of the endpoint.
  /// </summary>
  public override void Configure()
  {
    Delete(DeleteContributorRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("ContributorEndpoints"));
  }

  /// <summary>
  /// Overrides the FastApi HandleAsync method and manipulates the business logic of the objects.
  /// </summary>
  /// <param name="request">The Contributor Request Delete contract object.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
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

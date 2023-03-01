namespace Clean.Architecture.Web.ContributorEndpoints;

using Core.ContributorAggregate;
using SharedKernel.Interfaces;
using FastEndpoints;

/// <summary>
/// The Contributor Update endpoint.
/// </summary>
public class UpdateContributor : Endpoint<UpdateContributorRequest, UpdateContributorResponse>
{
  private readonly IRepository<Contributor> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="UpdateContributor"/> class.
  /// </summary>
  /// <param name="repository">The Contributor repository.</param>
  public UpdateContributor(IRepository<Contributor> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Overrides the FastApi Configure method and sets the route of the endpoint.
  /// </summary>
  public override void Configure()
  {
    Put("/Contributors");
    AllowAnonymous();
    Options(x => x
      .WithTags("ContributorEndpoints"));
  }

  /// <summary>
  /// Overrides the FastApi HandleAsync method and manipulates the business logic of the objects.
  /// </summary>
  /// <param name="request">The Contributor Request Update contract object.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  public override async Task HandleAsync(
    UpdateContributorRequest request,
    CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      ThrowError("Name is required");
    }

    var existingContributor = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (existingContributor == null)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    existingContributor.UpdateName(request.Name);

    await _repository.UpdateAsync(existingContributor, cancellationToken);

    var contributor =
      new ContributorRecord(contributorId: existingContributor.Id, contributorName: existingContributor.Name);

    var response = new UpdateContributorResponse { Contributor = contributor };

    await SendAsync(response, cancellation: cancellationToken);
  }
}

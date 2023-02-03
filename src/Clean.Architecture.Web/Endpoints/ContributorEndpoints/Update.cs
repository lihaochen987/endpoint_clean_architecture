namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

using Core.ContributorAggregate;
using SharedKernel.Interfaces;
using FastEndpoints;

/// <summary>
/// TODO.
/// </summary>
public class Update : Endpoint<UpdateContributorRequest, UpdateContributorResponse>
{
  private readonly IRepository<Contributor> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="Update"/> class.
  /// </summary>
  /// <param name="repository">TODO LATER.</param>
  public Update(IRepository<Contributor> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  public override void Configure()
  {
    Put(CreateContributorRequest.Route);
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
      await SendNotFoundAsync();
      return;
    }

    existingContributor.UpdateName(request.Name);

    await _repository.UpdateAsync(existingContributor, cancellationToken);

    var response = new UpdateContributorResponse(
      contributor: new ContributorRecord(existingContributor.Id, existingContributor.Name));

    await SendAsync(response);
  }
}

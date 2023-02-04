namespace Clean.Architecture.Web.ContributorEndpoints;

using Core.ContributorAggregate;
using Core.ProjectAggregate.Specifications;
using SharedKernel.Interfaces;
using FastEndpoints;

/// <summary>
/// TODO.
/// </summary>
public class GetById : Endpoint<GetContributorByIdRequest, ContributorRecord>
{
  private readonly IRepository<Contributor> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="GetById"/> class.
  /// </summary>
  /// <param name="repository">TODO LATER.</param>
  public GetById(IRepository<Contributor> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  public override void Configure()
  {
    Get(GetContributorByIdRequest.Route);
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
    GetContributorByIdRequest request,
    CancellationToken cancellationToken)
  {
    var spec = new ContributorByIdSpec(request.ContributorId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var response = new ContributorRecord(entity.Id, entity.Name);

    await SendAsync(response, cancellation: cancellationToken);
  }
}

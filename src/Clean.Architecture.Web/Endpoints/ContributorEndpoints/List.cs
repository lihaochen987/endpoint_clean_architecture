namespace Clean.Architecture.Web.Endpoints.ContributorEndpoints;

using Core.ContributorAggregate;
using SharedKernel.Interfaces;
using FastEndpoints;

/// <summary>
/// TODO.
/// </summary>
public class List : EndpointWithoutRequest<ContributorListResponse>
{
  private readonly IRepository<Contributor> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="List"/> class.
  /// </summary>
  /// <param name="repository">TODO LATER.</param>
  public List(IRepository<Contributor> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  public override void Configure()
  {
    Get("/Contributors");
    AllowAnonymous();
    Options(x => x
      .WithTags("ContributorEndpoints"));
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="cancellationToken">TODO LATER.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var contributors = await _repository.ListAsync(cancellationToken);
    var response = new ContributorListResponse()
    {
      Contributors = contributors
        .Select(project => new ContributorRecord(project.Id, project.Name))
        .ToList(),
    };

    await SendAsync(response);
  }
}

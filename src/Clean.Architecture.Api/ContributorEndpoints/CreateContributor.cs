namespace Clean.Architecture.Web.ContributorEndpoints;

using Core.ContributorAggregate;
using SharedKernel.Interfaces;
using FastEndpoints;

/// <summary>
/// The Contributor Create endpoint.
/// </summary>
public class CreateContributor : Endpoint<CreateContributorRequest, CreateContributorResponse>
{
  private readonly IRepository<Contributor> _repository;

  /// <summary>
  /// Initializes a new instance of the <see cref="CreateContributor"/> class.
  /// </summary>
  /// <param name="repository">The Contributor repository.</param>
  public CreateContributor(IRepository<Contributor> repository)
  {
    _repository = repository;
  }

  /// <summary>
  /// Overrides the FastApi Configure method and sets the route of the endpoint.
  /// </summary>
  public override void Configure()
  {
    Post(CreateContributorRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("ContributorEndpoints"));
  }

  /// <summary>
  /// Overrides the FastApi HandleAsync method and manipulates the business logic of the objects.
  /// </summary>
  /// <param name="request">The Contributor Request Create contract object.</param>
  /// <param name="cancellationToken">The cancellation token.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  public override async Task HandleAsync(
    CreateContributorRequest request,
    CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      ThrowError("Name is required");
    }

    // Create Domain Model object from request contract.
    var newContributor = new Contributor(request.Name);

    // Add Domain Model object to the database.
    var createdItem = await _repository.AddAsync(newContributor, cancellationToken);
    Logger.LogInformation("Contributor created, 'Name' = {NewContributorName}", newContributor.Name);

    // Return a domain model response contract.
    var response = new CreateContributorResponse { Id = createdItem.Id, Name = createdItem.Name };

    await SendAsync(response, cancellation: cancellationToken);
  }
}

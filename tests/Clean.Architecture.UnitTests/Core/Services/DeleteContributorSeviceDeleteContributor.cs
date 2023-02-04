namespace Clean.Architecture.UnitTests.Core.Services;

using System.Threading.Tasks;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.Services;
using SharedKernel.Interfaces;
using MediatR;
using Moq;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
public class DeleteContributorServiceDeleteContributor
{
  private readonly Mock<IRepository<Contributor>> _mockRepo = new Mock<IRepository<Contributor>>();
  private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
  private readonly DeleteContributorService _service;

  /// <summary>
  /// Initializes a new instance of the <see cref="DeleteContributorServiceDeleteContributor"/> class.
  /// </summary>
  public DeleteContributorServiceDeleteContributor()
  {
    _service = new DeleteContributorService(_mockRepo.Object, _mockMediator.Object);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ReturnsNotFoundGivenCantFindContributor()
  {
    var result = await _service.DeleteContributor(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}

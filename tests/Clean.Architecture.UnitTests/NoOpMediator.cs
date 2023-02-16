namespace Clean.Architecture.UnitTests;

using System.Runtime.CompilerServices;
using MediatR;

/// <summary>
/// TODO.
/// </summary>
public class NoOpMediator : IMediator
{
  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="notification">TODO LATER.</param>
  /// <param name="cancellationToken">TODO LATER2.</param>
  /// <returns>TODO LATER3.</returns>
  public Task Publish(object notification, CancellationToken cancellationToken = default)
  {
    return Task.CompletedTask;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="notification">TODO LATER.</param>
  /// <param name="cancellationToken">TODO LATER2.</param>
  /// <typeparam name="TNotification">TODO LATER3.</typeparam>
  /// <returns>TODO LATER4.</returns>
  public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
    where TNotification : INotification
  {
    return Task.CompletedTask;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="request">TODO LATER1.</param>
  /// <param name="cancellationToken">TODO LATER2.</param>
  /// <typeparam name="TResponse">TODO LATER3.</typeparam>
  /// <returns>TODO LATER4.</returns>
  public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
  {
    return Task.FromResult<TResponse>(default!);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="request">TODO 1.</param>
  /// <param name="cancellationToken">TODO 2.</param>
  /// <typeparam name="TRequest">TODO 3.</typeparam>
  /// <returns>TODO 4.</returns>
  /// <exception cref="NotImplementedException">TODO 5.</exception>
  public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default)
    where TRequest : IRequest
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="request">TODO LATER.</param>
  /// <param name="cancellationToken">TODO LATER2.</param>
  /// <returns>TODO LATER3.</returns>
  public Task<object?> Send(object request, CancellationToken cancellationToken = default)
  {
    return Task.FromResult<object?>(default);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="request">TODO LATER.</param>
  /// <param name="cancellationToken">TODO LATER2.</param>
  /// <typeparam name="TResponse">TODO LATER3.</typeparam>
  /// <returns>TODO LATER4.</returns>
  public async IAsyncEnumerable<TResponse> CreateStream<TResponse>(
    IStreamRequest<TResponse> request,
    [EnumeratorCancellation] CancellationToken cancellationToken = default)
  {
    await Task.CompletedTask;
    yield break;
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="request">TODO LATER2.</param>
  /// <param name="cancellationToken">TODO LATER3.</param>
  /// <returns>TODO LATER4.</returns>
  public async IAsyncEnumerable<object?> CreateStream(
    object request,
    [EnumeratorCancellation] CancellationToken cancellationToken = default)
  {
    await Task.CompletedTask;
    yield break;
  }
}

namespace Clean.Architecture.Infrastructure;

using Core.Interfaces;

/// <summary>
/// TODO.
/// </summary>
public class FakeEmailSender : IEmailSender
{
  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="to">TODO LATER.</param>
  /// <param name="from">TODO LATER2.</param>
  /// <param name="subject">TODO LATER3.</param>
  /// <param name="body">TODO LATER4.</param>
  /// <returns>TODO LATER5.</returns>
  public Task SendEmailAsync(string to, string from, string subject, string body)
  {
    return Task.CompletedTask;
  }
}

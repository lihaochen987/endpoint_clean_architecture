namespace Clean.Architecture.Core.ProjectAggregate.Handlers;

using Ardalis.GuardClauses;
using Interfaces;
using Events;
using MediatR;

/// <summary>
/// TODO.
/// </summary>
public class ItemCompletedEmailNotificationHandler : INotificationHandler<ToDoItemCompletedEvent>
{
  private readonly IEmailSender _emailSender;

  /// <summary>
  /// Initializes a new instance of the <see cref="ItemCompletedEmailNotificationHandler"/> class.
  /// In a REAL app you might want to use the Outbox pattern and a command/queue here...
  /// </summary>
  /// <param name="emailSender">TODO.</param>
  public ItemCompletedEmailNotificationHandler(IEmailSender emailSender)
  {
    _emailSender = emailSender;
  }

  /// <summary>
  /// TODO.
  /// configure a test email server to demo this works
  /// https://ardalis.com/configuring-a-local-test-email-server.
  /// </summary>
  /// <param name="domainEvent">TODO.</param>
  /// <param name="cancellationToken">TODO later1.</param>
  /// <returns>TODO later2.</returns>
  public Task Handle(ToDoItemCompletedEvent domainEvent, CancellationToken cancellationToken)
  {
    Guard.Against.Null(domainEvent, nameof(domainEvent));

    return _emailSender.SendEmailAsync(
      "test@test.com",
      "test@test.com",
      $"{domainEvent.CompletedItem.Title} was completed.",
      domainEvent.CompletedItem.ToString());
  }
}

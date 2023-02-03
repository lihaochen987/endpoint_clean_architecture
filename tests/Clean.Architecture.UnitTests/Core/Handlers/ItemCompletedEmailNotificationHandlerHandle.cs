namespace Clean.Architecture.UnitTests.Core.Handlers;

using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.ProjectAggregate;
using Clean.Architecture.Core.ProjectAggregate.Events;
using Clean.Architecture.Core.ProjectAggregate.Handlers;
using Moq;
using Xunit;

/// <summary>
/// TODO.
/// </summary>
public class ItemCompletedEmailNotificationHandlerHandle
{
  /// <summary>
  /// TODO.
  /// </summary>
  private ItemCompletedEmailNotificationHandler _handler;
  /// <summary>
  /// TODO.
  /// </summary>
  private Mock<IEmailSender> _emailSenderMock;

  /// <summary>
  /// Initializes a new instance of the <see cref="ItemCompletedEmailNotificationHandlerHandle"/> class.
  /// </summary>
  public ItemCompletedEmailNotificationHandlerHandle()
  {
    _emailSenderMock = new Mock<IEmailSender>();
    _handler = new ItemCompletedEmailNotificationHandler(_emailSenderMock.Object);
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task ThrowsExceptionGivenNullEventArgument()
  {
#nullable disable
    Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
#nullable enable
  }

  /// <summary>
  /// TODO.
  /// </summary>
  /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
  [Fact]
  public async Task SendsEmailGivenEventInstance()
  {
    await _handler.Handle(new ToDoItemCompletedEvent(new ToDoItem()), CancellationToken.None);

    _emailSenderMock.Verify(
      sender => sender.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
      Times.Once);
  }
}

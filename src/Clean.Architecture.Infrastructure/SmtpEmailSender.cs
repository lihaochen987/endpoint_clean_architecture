namespace Clean.Architecture.Infrastructure;

using System.Net.Mail;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

/// <summary>
/// The actual implementation of the EmailSender service.
/// </summary>
public class SmtpEmailSender : IEmailSender
{
  /// <summary>
  /// The logger.
  /// </summary>
  private readonly ILogger<SmtpEmailSender> _logger;

  /// <summary>
  /// Initializes a new instance of the <see cref="SmtpEmailSender"/> class.
  /// </summary>
  /// <param name="logger">The logger object.</param>
  public SmtpEmailSender(ILogger<SmtpEmailSender> logger)
  {
    this._logger = logger;
  }

  /// <inheritdoc/>
  public async Task SendEmailAsync(string to, string from, string subject, string body)
  {
    var emailClient = new SmtpClient("localhost");
    var message = new MailMessage { From = new MailAddress(from), Subject = subject, Body = body };
    message.To.Add(new MailAddress(to));
    await emailClient.SendMailAsync(message);
    _logger.LogWarning("Sending email to {To} from {From} with subject {Subject}", to, from, subject);
  }
}

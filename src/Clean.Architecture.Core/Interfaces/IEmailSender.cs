namespace Clean.Architecture.Core.Interfaces;

using System.Threading.Tasks;

/// <summary>
/// The interface of the EmailSender service.
/// </summary>
public interface IEmailSender
{
  /// <summary>
  /// The method responsible for sending the email.
  /// </summary>
  /// <param name="to">The email address the Email will be sent to.</param>
  /// <param name="from">The email address the mail will be sent from.</param>
  /// <param name="subject">The subject line of the email.</param>
  /// <param name="body">The body of the email.</param>
  /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
  Task SendEmailAsync(string to, string from, string subject, string body);
}

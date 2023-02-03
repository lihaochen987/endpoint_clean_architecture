namespace Clean.Architecture.Web.ViewModels;

/// <summary>
/// TODO.
/// </summary>
public class ErrorViewModel
{
  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public string? RequestId { get; set; }

  /// <summary>
  /// Gets a value indicating whether tODO.
  /// </summary>
  public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

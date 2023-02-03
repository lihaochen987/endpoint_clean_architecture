namespace Clean.Architecture.Core.ProjectAggregate;

using Ardalis.SmartEnum;

/// <summary>
/// TODO.
/// </summary>
public class PriorityStatus : SmartEnum<PriorityStatus>
{
  /// <summary>
  /// TODO.
  /// </summary>
  public static readonly PriorityStatus Backlog = new (nameof(Backlog), 0);

  /// <summary>
  /// TODO.
  /// </summary>
  public static readonly PriorityStatus Critical = new (nameof(Critical), 1);

  /// <summary>
  /// Initializes a new instance of the <see cref="PriorityStatus"/> class.
  /// </summary>
  /// <param name="name">TODO.</param>
  /// <param name="value">TODO later.</param>
  protected PriorityStatus(string name, int value)
        : base(name, value)
    {
    }
}

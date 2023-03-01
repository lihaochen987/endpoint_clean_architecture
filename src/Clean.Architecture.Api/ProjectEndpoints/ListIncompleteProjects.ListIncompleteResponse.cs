namespace Clean.Architecture.Web.ProjectEndpoints;

/// <summary>
/// TODO.
/// </summary>
public class ListIncompleteResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ListIncompleteResponse"/> class.
  /// </summary>
  /// <param name="projectId">TODO LATER.</param>
  /// <param name="incompleteItems">TODO LATER2.</param>
  public ListIncompleteResponse(int projectId, List<ToDoItemRecord> incompleteItems)
  {
    ProjectId = projectId;
    IncompleteItems = incompleteItems;
  }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public int ProjectId { get; set; }

  /// <summary>
  /// Gets or sets tODO.
  /// </summary>
  public List<ToDoItemRecord> IncompleteItems { get; set; }
}

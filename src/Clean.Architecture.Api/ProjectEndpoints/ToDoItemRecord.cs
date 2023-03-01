namespace Clean.Architecture.Web.ProjectEndpoints;

/// <summary>
/// The shared response class of to-do items.
/// </summary>
/// <param name="todoItemId">The Id of the to-do item.</param>
/// <param name="todoItemTitle">The Title of the to-do item.</param>
/// <param name="todoItemDescription">The Description of the to-do item.</param>
/// <param name="todoItemIsDone">The status indicating whether the to-do item is done.</param>
public record ToDoItemRecord(int todoItemId, string todoItemTitle, string todoItemDescription, bool todoItemIsDone);

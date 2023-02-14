namespace Clean.Architecture.Web.ProjectEndpoints;

/// <summary>
/// TODO.
/// </summary>
/// <param name="id">TODO LATER.</param>
/// <param name="title">TODO LATER 2.</param>
/// <param name="description">TODO LATER3.</param>
/// <param name="isDone">TODO LATER4.</param>
public record ToDoItemRecord(int id, string title, string description, bool isDone);

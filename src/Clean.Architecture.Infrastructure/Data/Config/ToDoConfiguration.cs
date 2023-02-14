namespace Clean.Architecture.Infrastructure.Data.Config;

using Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Configures the properties of the To-do item in the database.
/// </summary>
public class ToDoConfiguration : IEntityTypeConfiguration<ToDoItem>
{
  /// <summary>
  /// Defines the properties of the To-do item object in the database.
  /// </summary>
  /// <param name="builder">The builder which builds the entity.</param>
  public void Configure(EntityTypeBuilder<ToDoItem> builder)
  {
    builder.Property(t => t.Title)
      .IsRequired();
    builder.Property(t => t.ContributorId)
      .IsRequired(false);
  }
}

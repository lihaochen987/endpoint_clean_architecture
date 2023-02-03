namespace Clean.Architecture.Infrastructure.Data.Config;

using Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// TODO LATER.
/// </summary>
public class ToDoConfiguration : IEntityTypeConfiguration<ToDoItem>
{
  /// <summary>
  /// TODO LATER1.
  /// </summary>
  /// <param name="builder">TODO LATER2.</param>
  public void Configure(EntityTypeBuilder<ToDoItem> builder)
  {
    builder.Property(t => t.Title)
      .IsRequired();
    builder.Property(t => t.ContributorId)
      .IsRequired(false);
  }
}

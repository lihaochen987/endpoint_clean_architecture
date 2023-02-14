namespace Clean.Architecture.Infrastructure.Data.Config;

using Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Configures the properties of the Project in the database.
/// </summary>
public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
  /// <summary>
  /// Defines the properties of the Project object in the database.
  /// </summary>
  /// <param name="builder">The builder which builds the entity.</param>
  public void Configure(EntityTypeBuilder<Project> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(100)
      .IsRequired();

    builder.Property(p => p.Priority)
      .HasConversion(
        p => p.Value,
        p => PriorityStatus.FromValue(p));
  }
}

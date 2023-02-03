namespace Clean.Architecture.Infrastructure.Data.Config;

using Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// TODO LATER.
/// </summary>
public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
  /// <summary>
  /// TODO LATER2.
  /// </summary>
  /// <param name="builder">TODO LATER3.</param>
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

namespace Clean.Architecture.Infrastructure.Data.Config;

using Core.ContributorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Configures the properties of the Contributor in the database.
/// </summary>
public class ContributorConfiguration : IEntityTypeConfiguration<Contributor>
{
  /// <summary>
  /// Defines the properties of the Contributor object in the database.
  /// </summary>
  /// <param name="builder">The builder which builds the entity.</param>
  public void Configure(EntityTypeBuilder<Contributor> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(100)
      .IsRequired();
  }
}

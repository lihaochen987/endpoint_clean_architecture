namespace Clean.Architecture.Infrastructure.Data.Config;

using Core.ContributorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// TODO LATER.
/// </summary>
public class ContributorConfiguration : IEntityTypeConfiguration<Contributor>
{
  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="builder">TODO LATER2.</param>
  public void Configure(EntityTypeBuilder<Contributor> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(100)
      .IsRequired();
  }
}

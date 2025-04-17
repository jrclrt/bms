using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class HouseholdConfiguration : IEntityTypeConfiguration<Household>
{
    public void Configure(EntityTypeBuilder<Household> builder)
    {
        builder.ToTable("Household");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.HouseholdName).HasMaxLength(100).IsRequired(true);
        builder.Property(h => h.Street).HasMaxLength(100).IsRequired(true);
        builder.Property(h => h.Barangay).HasMaxLength(100).IsRequired(true);
        builder.Property(h => h.District).HasMaxLength(100).IsRequired(true);
        builder.Property(h => h.City).HasMaxLength(100).IsRequired(true);
        builder.Property(h => h.Region).HasMaxLength(100).IsRequired(true);
        builder.Property(h => h.Country).HasMaxLength(100).IsRequired(true);
        builder.Property(h => h.Zipcode).HasMaxLength(100).IsRequired(true);

        builder.Property(h => h.IsDeleted).HasDefaultValue(false);
        builder.Property(h => h.CreatedBy).HasMaxLength(100).IsRequired(true);
        builder.Property(h => h.UpdatedBy).HasMaxLength(100).IsRequired(false);
        builder.Property(h => h.CreatedDate).HasColumnType("datetime").IsRequired(true);
        builder.Property(h => h.UpdatedDate).HasColumnType("datetime").IsRequired(false);
    }
}

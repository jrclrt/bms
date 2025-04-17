using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ResidentConfiguration : IEntityTypeConfiguration<Resident>
{
    public void Configure(EntityTypeBuilder<Resident> builder)
    {
        builder.ToTable("Resident");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.FirstName).HasMaxLength(100).IsRequired(true);
        builder.Property(r => r.MiddleName).HasMaxLength(100).IsRequired(false);
        builder.Property(r => r.LastName).HasMaxLength(100).IsRequired(true);
        builder.Property(r => r.Suffix).HasMaxLength(20).IsRequired(false);
        builder.Property(r => r.BirthDate).HasColumnType("datetime").IsRequired(true);
        builder.Property(r => r.Gender).HasMaxLength(20).IsRequired(true);
        builder.Property(r => r.Nationality).HasMaxLength(20).IsRequired(true);

        builder.Property(r => r.IsDeleted).HasDefaultValue(false);
        builder.Property(r => r.CreatedBy).HasMaxLength(100).IsRequired(true);
        builder.Property(r => r.UpdatedBy).HasMaxLength(100).IsRequired(false);
        builder.Property(r => r.CreatedDate).HasColumnType("datetime").IsRequired(true);
        builder.Property(r => r.UpdatedDate).HasColumnType("datetime").IsRequired(false);
    }
}

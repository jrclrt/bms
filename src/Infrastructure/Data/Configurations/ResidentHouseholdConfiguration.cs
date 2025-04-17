using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class ResidentHouseholdConfiguration : IEntityTypeConfiguration<ResidentHousehold>
{
    public void Configure(EntityTypeBuilder<ResidentHousehold> builder)
    {
        builder.ToTable("ResidentHousehold");

        builder.HasKey(rh => rh.Id);

        builder.HasKey(rh => new {rh.ResidentId, rh.HouseholdId});
        builder.HasOne(rh => rh.Resident).WithMany(r => r.ResidentHouseholds).HasForeignKey(rh => rh.ResidentId);
        builder.HasOne(rh => rh.Household).WithMany(h => h.ResidentHouseholds).HasForeignKey(rh => rh.HouseholdId);

        builder.Property(rh => rh.IsDeleted).HasDefaultValue(false);
        builder.Property(rh => rh.CreatedBy).HasMaxLength(100).IsRequired(true);
        builder.Property(rh => rh.UpdatedBy).HasMaxLength(100).IsRequired(false);
        builder.Property(rh => rh.CreatedDate).HasColumnType("datetime").IsRequired(true);
        builder.Property(rh => rh.UpdatedDate).HasColumnType("datetime").IsRequired(false);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToToAirline.Entities;

namespace ToToAirline.Configurations
{
    public class SecurityCheckConfiguration : IEntityTypeConfiguration<SecurityCheck>
    {
        public void Configure(EntityTypeBuilder<SecurityCheck> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.Passenger).WithMany(p => p.SecurityChecks).HasForeignKey(s => s.PassengerId);
        }
    }
}
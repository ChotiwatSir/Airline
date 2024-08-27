using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToToAirline.Entities;

namespace ToToAirline.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).HasMaxLength(20);
            builder.Property(p => p.LastName).HasMaxLength(20);
            builder.Property(p => p.PassportNumber).HasMaxLength(20);
           
        }
    }
}
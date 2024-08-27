using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToToAirline.Entities;

namespace ToToAirline.Configurations
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(ap => ap.Id);
            builder.Property(ap => ap.City).HasMaxLength(30);
            builder.Property(ap => ap.County).HasMaxLength(30);
            builder.Property(ap =>ap.State).HasMaxLength(30);
           
        }
    }
}
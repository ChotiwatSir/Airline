using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToToAirline.Entities;

namespace ToToAirline.Configurations
{
    public class FlightManifestConfiguration : IEntityTypeConfiguration<FlightManifest>
    {
        public void Configure(EntityTypeBuilder<FlightManifest> builder)
        {
            builder.HasKey(fm => fm.Id);
            builder.HasOne(fm => fm.Flight).WithMany(f => f.FlightManifests).HasForeignKey(fm => fm.FlightId);
            builder.HasOne(fm => fm.Booking).WithMany(b => b.FlightManifests).HasForeignKey(fm => fm.BookingId);
            
        }
    }
}
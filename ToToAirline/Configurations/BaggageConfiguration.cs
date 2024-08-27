using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToToAirline.Entities;

namespace ToToAirline.Configurations
{
    public class BaggageConfiguration : IEntityTypeConfiguration<Baggage>
    {
        public void Configure(EntityTypeBuilder<Baggage> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.WeightInKg).HasPrecision(4, 2);
            builder.HasOne(b => b.Booking).WithMany(b => b.Baggages).HasForeignKey(b => b.BookingId);
            
        }
    }
}
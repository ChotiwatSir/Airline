
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToToAirline.Entities;

namespace ToToAirline.Configurations
{
    public class BaggageCheckConfiguration : IEntityTypeConfiguration<BaggageCheck>
    {
        public void Configure(EntityTypeBuilder<BaggageCheck> builder)
        {
            builder.HasKey(bc => bc.Id);

            builder.Property(bc => bc.CheckResult)
                        .HasMaxLength(50);

            builder.HasOne(bc => bc.Booking)
                        .WithMany(b => b.BaggageChecks)
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasForeignKey(bc => bc.BookingId);

            builder.HasOne(bc => bc.Passenger)
                        .WithOne(b => b.BaggageCheck)
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasForeignKey<BaggageCheck>(bc => bc.PassengerId);


        }
    }
}
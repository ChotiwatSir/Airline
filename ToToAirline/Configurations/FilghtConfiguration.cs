using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToToAirline.Entities;

namespace ToToAirline.Configurations
{
    public class FilghtConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.DepartureGate)
                                        .HasMaxLength(20);
            builder.Property(f => f.ArrivingGate)
                                        .HasMaxLength(20);
                                        
            builder.HasOne(f => f.Airline)
                                  .WithMany(a => a.Flights)
                                  .HasForeignKey(f => f.AirlineId);

            builder.HasOne(f => f.ArrivingAirport)
                                            .WithOne(f => f.ArrivingFlight)
                                            .OnDelete(DeleteBehavior.NoAction)
                                            .HasForeignKey<Flight>(f => f.ArrivingAirportId);

            builder.HasOne(f => f.DepartingAirport)
                                            .WithOne(f => f.DepartingFlight)
                                            .OnDelete(DeleteBehavior.NoAction)
                                            .HasForeignKey<Flight>(f => f.DepartureAirportId);

            builder.HasIndex(f => f.ArrivingAirportId)
                                        .IsUnique(false);
            builder.HasIndex(f => f.DepartureAirportId)
                                        .IsUnique(false);

        }
    }
}
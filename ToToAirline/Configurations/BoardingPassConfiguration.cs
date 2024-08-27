using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToToAirline.Entities;

namespace ToToAirline.Configurations
{
    public class BoardingPassConfiguration : IEntityTypeConfiguration<BoardingPass>
    {
        public void Configure(EntityTypeBuilder<BoardingPass> builder)
        {
            builder.HasKey(bp => bp.Id);
            builder.HasOne(bp => bp.Booking).WithMany(b => b.BoardingPasses).HasForeignKey(bp => bp.BookingId);
        }
    }
}
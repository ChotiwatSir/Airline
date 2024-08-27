using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToToAirline.Entities;

namespace ToToAirline.Configurations
{
    public class NoFlyListConfiguration : IEntityTypeConfiguration<NoFlyList>
    {
        public void Configure(EntityTypeBuilder<NoFlyList> builder)
        {
            builder.HasKey(n => n.Id);
            builder.HasOne(n => n.Passenger).WithMany(p => p.NoFlyLists).HasForeignKey(n => n.PassengerId);
        }
    }
}
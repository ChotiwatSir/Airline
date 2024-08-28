using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToToAirline.Entities;

namespace ToToAirline.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(u => u.Name).HasMaxLength(50);

            builder.HasOne(x => x.Role).WithMany(r => r.Users).HasForeignKey(x => x.RoleId);

            builder.HasData(new User(Guid.Parse("6a1f4868-eb40-4174-818f-ab9e4990126d"), "Hiyashiman","Hiyashiman", Guid.Parse("7489392b-0a08-4754-b1da-4bc56a180240")));
            builder.HasData(new User(Guid.Parse("b7670f70-262c-46da-b936-9100611e2b1f"), "ToToSan", "ToToSan", Guid.Parse("8fc39f50-3b40-4465-b6c5-b97890dcd2ef")));
        }
    }
}
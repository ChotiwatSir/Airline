using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToToAirline.Entities;

namespace ToToAirline.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);

            builder.HasData(new Role(Guid.Parse("7489392b-0a08-4754-b1da-4bc56a180240"), "Admin"));
            builder.HasData(new Role(Guid.Parse("8fc39f50-3b40-4465-b6c5-b97890dcd2ef"), "User"));

        }
    }
}
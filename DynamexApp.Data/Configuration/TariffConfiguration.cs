using DynamexApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Data.Configuration
{
    class TariffConfiguration : IEntityTypeConfiguration<Tariff>
    {
        public void Configure(EntityTypeBuilder<Tariff> builder)
        {
            builder.HasOne(x => x.DeliveryType).WithMany(x => x.Tariffs).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.MinWeight).IsRequired(true);
            builder.Property(x => x.MinWeight).IsRequired(true);
            builder.Property(x => x.Price).IsRequired(true).HasColumnType("decimal(10,2)");
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x => x.ModifiedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
        }
    }
}

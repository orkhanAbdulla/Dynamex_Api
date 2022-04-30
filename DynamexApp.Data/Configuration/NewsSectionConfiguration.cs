﻿using DynamexApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Data.Configuration
{
    class NewsSectionConfiguration : IEntityTypeConfiguration<NewsSection>
    {
        public void Configure(EntityTypeBuilder<NewsSection> builder)
        {
            builder.Property(x => x.Title).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Subtitle).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x => x.ModifiedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
        }
    }
}

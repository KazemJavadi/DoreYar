﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfig
{
    internal class CardConfig : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(c => c.RegDate).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(c => c.NextReviewDate).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(p => p.Repetitions).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.Interval).IsRequired().HasDefaultValue(1);
            builder.Property(p => p.EasinessFactor).IsRequired().HasDefaultValue(0);
        }
    }
}

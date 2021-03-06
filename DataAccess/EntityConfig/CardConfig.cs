using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.HasMany(p => p.Images).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}

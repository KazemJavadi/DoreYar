using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfig
{
    internal class DeckConfig : IEntityTypeConfiguration<Deck>
    {
        public void Configure(EntityTypeBuilder<Deck> builder)
        {
            builder
                  .HasMany(c => c.Cards)
                  .WithOne()
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

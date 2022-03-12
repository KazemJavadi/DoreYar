using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfig
{
    internal class CardImageConfig : IEntityTypeConfiguration<CardImage>
    {
        public void Configure(EntityTypeBuilder<CardImage> builder)
        {
        }
    }
}

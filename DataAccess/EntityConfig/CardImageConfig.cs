using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfig
{
    internal class CardImageConfig : IEntityTypeConfiguration<CardImage>
    {
        public void Configure(EntityTypeBuilder<CardImage> builder)
        {
        }
    }
}

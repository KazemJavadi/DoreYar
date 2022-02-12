using DataAccess.EntityConfig;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        //{
        //    configurationBuilder.Properties<string>().HaveMaxLength(100);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Deck>(new DeckConfig());
            modelBuilder.ApplyConfiguration<Card>(new CardConfig());
        }

        public DbSet<Deck> Decks { get; set; }
    }
}
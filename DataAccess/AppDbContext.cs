using DataAccess.Entities;
using DataAccess.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppDbContext : IdentityDbContext<User>
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

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Deck> Decks { get; set; }
    }
}
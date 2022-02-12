using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess
{
    internal class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AppDbContext> optionBuilder = new();
            optionBuilder.UseSqlServer("server=.;database=YadYarDb;trusted_connection=true;");
            return new(optionBuilder.Options);
        }
    }
}

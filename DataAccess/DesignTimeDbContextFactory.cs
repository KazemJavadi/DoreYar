using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AppDbContext> optionBuilder = new();
            optionBuilder.UseSqlServer(Configuration.GetConfiguration()["ConnectionStrings:Default"]);
            return new(optionBuilder.Options);
        }
    }
}

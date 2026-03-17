using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NZWalks.API.Data
{
    public class NZWalksDbContextFactory : IDesignTimeDbContextFactory<NZWalksDbContext>
    {
        public NZWalksDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<NZWalksDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("NZWalksConnection"));

            return new NZWalksDbContext(optionsBuilder.Options);
        }
    }
}

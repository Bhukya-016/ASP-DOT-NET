using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class NZWalksAuthDbContextFactory : IDesignTimeDbContextFactory<NZWalksAuthDbContext>
{
    public NZWalksAuthDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<NZWalksAuthDbContext>();
        // Use the auth-specific connection string so migrations target the auth database
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("NZWalksAuthConnectionString"));

        return new NZWalksAuthDbContext(optionsBuilder.Options);
    }
}

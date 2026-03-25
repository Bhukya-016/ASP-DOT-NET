using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class NZWalksAuthDbContext : IdentityDbContext
{
    public NZWalksAuthDbContext(
        DbContextOptions<NZWalksAuthDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var readerRoleId = "4015bd1d-bd9c-4650-8106-5b4e8652d83f";
        var writerRoleId = "aa511dea-97fa-4413-a4fd-f69670512094";

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = readerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Reader",
                NormalizedName = "READER"
            },
            new IdentityRole
            {
                Id = writerRoleId,
                ConcurrencyStamp = writerRoleId,
                Name = "Writer",
                NormalizedName = "WRITER"
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}
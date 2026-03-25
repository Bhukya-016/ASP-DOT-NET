using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create Images table only if it does not already exist to avoid errors when
            // running this migration against a database that already contains the table.
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'dbo.Images', N'U') IS NULL
BEGIN
    CREATE TABLE [dbo].[Images]
    (
        [Id] uniqueidentifier NOT NULL PRIMARY KEY,
        [FileName] nvarchar(max) NOT NULL,
        [FileDescription] nvarchar(max) NULL,
        [FileExtension] nvarchar(max) NOT NULL,
        [FileSizeInBytes] bigint NOT NULL,
        [FilePath] nvarchar(max) NOT NULL
    );
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Only drop the Images table if it exists when rolling back this migration.
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'dbo.Images', N'U') IS NOT NULL
BEGIN
    DROP TABLE [dbo].[Images];
END
");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetProject.Migrations
{
    /// <inheritdoc />
    public partial class IMAsset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Price = table.Column<int>(type: "Int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}

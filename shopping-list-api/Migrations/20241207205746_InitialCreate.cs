using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace shopping_list_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "itemsapi");

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "itemsapi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "itemsapi",
                table: "Items",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b17b0981-e76f-48fb-a12e-d33eba793523"), "Queijo" },
                    { new Guid("d6089e16-62f7-4131-8ed4-13fbc2e1c85d"), "Paçoca" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items",
                schema: "itemsapi");
        }
    }
}

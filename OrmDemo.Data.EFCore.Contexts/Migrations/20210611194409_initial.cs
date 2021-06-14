using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrmDemo.Data.EFCore.Contexts.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 254, nullable: false),
                    FirstName = table.Column<string>(maxLength: 254, nullable: true),
                    LastName = table.Column<string>(maxLength: 254, nullable: true),
                    Email = table.Column<string>(maxLength: 254, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}

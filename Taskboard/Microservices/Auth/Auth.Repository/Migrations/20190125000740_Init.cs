using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    EMAIL = table.Column<string>(maxLength: 256, nullable: false),
                    FULL_NAME = table.Column<string>(maxLength: 256, nullable: false),
                    CREATED = table.Column<DateTime>(nullable: false),
                    PASSWORD_HASH = table.Column<byte[]>(nullable: false),
                    PASSWORD_SALT = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}

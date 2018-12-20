using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class contacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONTACTS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FIRST_USER_ID = table.Column<long>(nullable: false),
                    SECOND_USER_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTACTS_USERS_FIRST_USER_ID",
                        column: x => x.FIRST_USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CONTACTS_USERS_SECOND_USER_ID",
                        column: x => x.SECOND_USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTACTS_FIRST_USER_ID",
                table: "CONTACTS",
                column: "FIRST_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTACTS_SECOND_USER_ID",
                table: "CONTACTS",
                column: "SECOND_USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTACTS");
        }
    }
}

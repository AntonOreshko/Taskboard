using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class contactrequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONTACT_REQUESTS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SENDER_ID = table.Column<long>(nullable: false),
                    RECEIVER_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACT_REQUESTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTACT_REQUESTS_USERS_RECEIVER_ID",
                        column: x => x.RECEIVER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CONTACT_REQUESTS_USERS_SENDER_ID",
                        column: x => x.SENDER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTACT_REQUESTS_RECEIVER_ID",
                table: "CONTACT_REQUESTS",
                column: "RECEIVER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTACT_REQUESTS_SENDER_ID",
                table: "CONTACT_REQUESTS",
                column: "SENDER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTACT_REQUESTS");
        }
    }
}

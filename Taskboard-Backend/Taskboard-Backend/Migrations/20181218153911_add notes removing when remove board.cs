using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class addnotesremovingwhenremoveboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TASKS_BOARDS_BoardId1",
                table: "TASKS");

            migrationBuilder.DropIndex(
                name: "IX_TASKS_BoardId1",
                table: "TASKS");

            migrationBuilder.DropColumn(
                name: "BoardId1",
                table: "TASKS");

            migrationBuilder.CreateIndex(
                name: "IX_NOTES_BOARD_ID",
                table: "NOTES",
                column: "BOARD_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_NOTES_BOARDS_BOARD_ID",
                table: "NOTES",
                column: "BOARD_ID",
                principalTable: "BOARDS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NOTES_BOARDS_BOARD_ID",
                table: "NOTES");

            migrationBuilder.DropIndex(
                name: "IX_NOTES_BOARD_ID",
                table: "NOTES");

            migrationBuilder.AddColumn<long>(
                name: "BoardId1",
                table: "TASKS",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TASKS_BoardId1",
                table: "TASKS",
                column: "BoardId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TASKS_BOARDS_BoardId1",
                table: "TASKS",
                column: "BoardId1",
                principalTable: "BOARDS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

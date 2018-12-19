using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class setcompletedbynullableforsubtask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "COMPLETED_BY",
                table: "SUBTASKS",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "COMPLETED_BY",
                table: "SUBTASKS",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}

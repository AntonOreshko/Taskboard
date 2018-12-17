using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class setcompletedbyasnullable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "COMPLETED_BY",
                table: "TASKS",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "COMPLETED_BY",
                table: "TASKS",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}

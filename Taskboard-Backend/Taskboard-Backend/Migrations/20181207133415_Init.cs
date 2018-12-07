using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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

            migrationBuilder.CreateTable(
                name: "BOARDS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATED = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    NAME = table.Column<string>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOARDS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOARDS_USERS_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOTES",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATED = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    NAME = table.Column<string>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    BOARD_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NOTES_USERS_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TASKS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATED = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    COMPLETED = table.Column<bool>(nullable: false),
                    COMPLETED_BY = table.Column<long>(nullable: false),
                    NAME = table.Column<string>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    BOARD_ID = table.Column<long>(nullable: false),
                    BoardId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASKS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TASKS_BOARDS_BOARD_ID",
                        column: x => x.BOARD_ID,
                        principalTable: "BOARDS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TASKS_BOARDS_BoardId1",
                        column: x => x.BoardId1,
                        principalTable: "BOARDS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASKS_USERS_COMPLETED_BY",
                        column: x => x.COMPLETED_BY,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TASKS_USERS_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER_BOARDS",
                columns: table => new
                {
                    USER_ID = table.Column<long>(nullable: false),
                    BOARD_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_BOARDS", x => new { x.USER_ID, x.BOARD_ID });
                    table.ForeignKey(
                        name: "FK_USER_BOARDS_BOARDS_BOARD_ID",
                        column: x => x.BOARD_ID,
                        principalTable: "BOARDS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_BOARDS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SUBTASKS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATED = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    COMPLETED = table.Column<bool>(nullable: false),
                    COMPLETED_BY = table.Column<long>(nullable: false),
                    NAME = table.Column<string>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    TASK_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBTASKS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SUBTASKS_USERS_COMPLETED_BY",
                        column: x => x.COMPLETED_BY,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUBTASKS_USERS_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUBTASKS_TASKS_TASK_ID",
                        column: x => x.TASK_ID,
                        principalTable: "TASKS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOARDS_CREATED_BY",
                table: "BOARDS",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_NOTES_CREATED_BY",
                table: "NOTES",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_SUBTASKS_COMPLETED_BY",
                table: "SUBTASKS",
                column: "COMPLETED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_SUBTASKS_CREATED_BY",
                table: "SUBTASKS",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_SUBTASKS_TASK_ID",
                table: "SUBTASKS",
                column: "TASK_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TASKS_BOARD_ID",
                table: "TASKS",
                column: "BOARD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TASKS_BoardId1",
                table: "TASKS",
                column: "BoardId1");

            migrationBuilder.CreateIndex(
                name: "IX_TASKS_COMPLETED_BY",
                table: "TASKS",
                column: "COMPLETED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_TASKS_CREATED_BY",
                table: "TASKS",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_USER_BOARDS_BOARD_ID",
                table: "USER_BOARDS",
                column: "BOARD_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTES");

            migrationBuilder.DropTable(
                name: "SUBTASKS");

            migrationBuilder.DropTable(
                name: "USER_BOARDS");

            migrationBuilder.DropTable(
                name: "TASKS");

            migrationBuilder.DropTable(
                name: "BOARDS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}

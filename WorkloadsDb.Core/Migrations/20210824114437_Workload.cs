using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkloadsDb.Core.Migrations
{
    public partial class Workload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workload",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Started = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Stopped = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workload", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workload_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workload_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workload_AssignmentId",
                table: "Workload",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Workload_PersonId",
                table: "Workload",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workload");
        }
    }
}

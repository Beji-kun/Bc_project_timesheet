using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheetApp.Server.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimesheetID",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartWork = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndWork = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimesheetUsers",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TimeSheetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetUsers", x => new { x.UserID, x.TimeSheetID });
                    table.ForeignKey(
                        name: "FK_TimesheetUsers_Timesheets_TimeSheetID",
                        column: x => x.TimeSheetID,
                        principalTable: "Timesheets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimesheetUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyID",
                table: "Projects",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TimesheetID",
                table: "Projects",
                column: "TimesheetID");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetUsers_TimeSheetID",
                table: "TimesheetUsers",
                column: "TimeSheetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Company_CompanyID",
                table: "Projects",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Timesheets_TimesheetID",
                table: "Projects",
                column: "TimesheetID",
                principalTable: "Timesheets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Company_CompanyID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Timesheets_TimesheetID",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "TimesheetUsers");

            migrationBuilder.DropTable(
                name: "Timesheets");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CompanyID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TimesheetID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "TimesheetID",
                table: "Projects");
        }
    }
}

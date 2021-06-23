using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTimeTracking.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BossID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Bosses",
                columns: table => new
                {
                    BossID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeePersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bosses", x => x.BossID);
                    table.ForeignKey(
                        name: "FK_Bosses_Persons_EmployeePersonId",
                        column: x => x.EmployeePersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeTrackings",
                columns: table => new
                {
                    TimeTrackingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeePersonId = table.Column<int>(type: "int", nullable: true),
                    DayWorkingHours = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTrackings", x => x.TimeTrackingID);
                    table.ForeignKey(
                        name: "FK_TimeTrackings_Persons_EmployeePersonId",
                        column: x => x.EmployeePersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeRecords",
                columns: table => new
                {
                    TimeRocordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeTrackingID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeRecords", x => x.TimeRocordID);
                    table.ForeignKey(
                        name: "FK_TimeRecords_TimeTrackings_TimeTrackingID",
                        column: x => x.TimeTrackingID,
                        principalTable: "TimeTrackings",
                        principalColumn: "TimeTrackingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bosses_EmployeePersonId",
                table: "Bosses",
                column: "EmployeePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BossID",
                table: "Persons",
                column: "BossID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeRecords_TimeTrackingID",
                table: "TimeRecords",
                column: "TimeTrackingID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTrackings_EmployeePersonId",
                table: "TimeTrackings",
                column: "EmployeePersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Bosses_BossID",
                table: "Persons",
                column: "BossID",
                principalTable: "Bosses",
                principalColumn: "BossID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bosses_Persons_EmployeePersonId",
                table: "Bosses");

            migrationBuilder.DropTable(
                name: "TimeRecords");

            migrationBuilder.DropTable(
                name: "TimeTrackings");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Bosses");
        }
    }
}

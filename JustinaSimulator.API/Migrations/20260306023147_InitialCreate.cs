using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustinaSimulator.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Robots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CurrentX = table.Column<double>(type: "REAL", nullable: false),
                    CurrentY = table.Column<double>(type: "REAL", nullable: false),
                    CurrentZ = table.Column<double>(type: "REAL", nullable: false),
                    Trajectory = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DoctorName = table.Column<string>(type: "TEXT", nullable: false),
                    WarningsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    DangersCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalDistance = table.Column<double>(type: "REAL", nullable: false),
                    FailedClicks = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalDurationSeconds = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robots", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Robots");
        }
    }
}

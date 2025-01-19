using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab.Infrasturcture.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ReportNumber = table.Column<int>(type: "int", nullable: false),
                    PatientName = table.Column<string>(type: "longtext", nullable: true),
                    PatientSurname = table.Column<string>(type: "longtext", nullable: true),
                    PatientEmail = table.Column<string>(type: "longtext", nullable: true),
                    PatientAddress = table.Column<string>(type: "longtext", nullable: true),
                    PatientPhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PatientNumber = table.Column<int>(type: "int", nullable: false),
                    PatientDiagnosis = table.Column<string>(type: "longtext", nullable: true),
                    DiagnosisDetail = table.Column<string>(type: "longtext", nullable: true),
                    ReportDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReportPicture = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}

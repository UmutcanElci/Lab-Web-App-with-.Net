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
                name: "Lab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    LabName = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lab", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DoctorName = table.Column<string>(type: "longtext", nullable: true),
                    DoctorSurname = table.Column<string>(type: "longtext", nullable: true),
                    Specialization = table.Column<string>(type: "longtext", nullable: true),
                    LabId = table.Column<Guid>(type: "char(36)", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Lab_LabId",
                        column: x => x.LabId,
                        principalTable: "Lab",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ReportNumber = table.Column<int>(type: "int", nullable: false),
                    PatientName = table.Column<string>(type: "longtext", nullable: false),
                    PatientSurname = table.Column<string>(type: "longtext", nullable: false),
                    PatientMail = table.Column<string>(type: "longtext", nullable: true),
                    PatientAddress = table.Column<string>(type: "longtext", nullable: true),
                    PatientPhoneNumber = table.Column<long>(type: "bigint", nullable: true),
                    PatientDiagnosis = table.Column<string>(type: "longtext", nullable: true),
                    DiagnosisDetail = table.Column<string>(type: "longtext", nullable: true),
                    ReportDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReportPicture = table.Column<string>(type: "longtext", nullable: true),
                    LabId = table.Column<Guid>(type: "char(36)", nullable: false),
                    DoctorId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Lab_LabId",
                        column: x => x.LabId,
                        principalTable: "Lab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_LabId",
                table: "Doctors",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DoctorId",
                table: "Reports",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_LabId",
                table: "Reports",
                column: "LabId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Lab");
        }
    }
}

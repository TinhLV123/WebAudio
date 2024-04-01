using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAudio.Migrations
{
    /// <inheritdoc />
    public partial class NoiDungs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoiDungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskId = table.Column<string>(type: "TEXT", nullable: false),
                    Channel = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Start = table.Column<float>(type: "REAL", nullable: true),
                    End = table.Column<float>(type: "REAL", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Text_norm = table.Column<string>(type: "TEXT", nullable: true),
                    NguoiTao = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NguoiCapNhat = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoiDungs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuanLyFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskId = table.Column<string>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DateToFile = table.Column<DateTime>(type: "TEXT", maxLength: 300, nullable: false),
                    IsStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    NguoiTao = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NguoiCapNhat = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ThoiGianCapNhat = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLyFiles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoiDungs");

            migrationBuilder.DropTable(
                name: "QuanLyFiles");
        }
    }
}

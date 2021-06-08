using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TiendaServicios.Api.Autor.Migrations
{
    public partial class _InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    BookAuthorGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicGrade",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookAuthorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AcademicCenter = table.Column<string>(nullable: true),
                    GradeDate = table.Column<DateTime>(nullable: false),
                    AcademicGradeGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicGrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicGrade_BookAuthor_BookAuthorId",
                        column: x => x.BookAuthorId,
                        principalTable: "BookAuthor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGrade_BookAuthorId",
                table: "AcademicGrade",
                column: "BookAuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicGrade");

            migrationBuilder.DropTable(
                name: "BookAuthor");
        }
    }
}

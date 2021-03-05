using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AddElementToFilterName.Migrations
{
    public partial class CreatetblFilterValuesAddFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblFilterNameAddFilter",
                table: "tblFilterNameAddFilter");

            migrationBuilder.RenameTable(
                name: "tblFilterNameAddFilter",
                newName: "tblFilterNamesAddFilter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblFilterNamesAddFilter",
                table: "tblFilterNamesAddFilter",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tblFilterValuesAddFilter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFilterValuesAddFilter", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblFilterValuesAddFilter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblFilterNamesAddFilter",
                table: "tblFilterNamesAddFilter");

            migrationBuilder.RenameTable(
                name: "tblFilterNamesAddFilter",
                newName: "tblFilterNameAddFilter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblFilterNameAddFilter",
                table: "tblFilterNameAddFilter",
                column: "Id");
        }
    }
}

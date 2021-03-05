using Microsoft.EntityFrameworkCore.Migrations;

namespace AddElementToFilterName.Migrations
{
    public partial class CreatetblFilterNameValuesAddFilter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblFilterNameValuesAddFilter",
                columns: table => new
                {
                    FilterNameId = table.Column<int>(type: "integer", nullable: false),
                    FilterValueId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFilterNameValuesAddFilter", x => new { x.FilterNameId, x.FilterValueId });
                    table.ForeignKey(
                        name: "FK_tblFilterNameValuesAddFilter_tblFilterNamesAddFilter_Filter~",
                        column: x => x.FilterNameId,
                        principalTable: "tblFilterNamesAddFilter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblFilterNameValuesAddFilter_tblFilterValuesAddFilter_Filte~",
                        column: x => x.FilterValueId,
                        principalTable: "tblFilterValuesAddFilter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblFilterNameValuesAddFilter_FilterValueId",
                table: "tblFilterNameValuesAddFilter",
                column: "FilterValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblFilterNameValuesAddFilter");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class ProcessResponseIdColumnChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProcessResponse",
                newName: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "ProcessResponse",
                newName: "Id");
        }
    }
}

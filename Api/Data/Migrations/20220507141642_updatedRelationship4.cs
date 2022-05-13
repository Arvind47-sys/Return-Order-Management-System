using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class updatedRelationship4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessResponse",
                table: "ProcessResponse");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProcessResponse",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProcessRequestId",
                table: "ProcessResponse",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessResponse",
                table: "ProcessResponse",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessResponse_ProcessRequestId",
                table: "ProcessResponse",
                column: "ProcessRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessResponse_ProcessRequest_ProcessRequestId",
                table: "ProcessResponse",
                column: "ProcessRequestId",
                principalTable: "ProcessRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessResponse_ProcessRequest_ProcessRequestId",
                table: "ProcessResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessResponse",
                table: "ProcessResponse");

            migrationBuilder.DropIndex(
                name: "IX_ProcessResponse_ProcessRequestId",
                table: "ProcessResponse");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProcessResponse");

            migrationBuilder.DropColumn(
                name: "ProcessRequestId",
                table: "ProcessResponse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessResponse",
                table: "ProcessResponse",
                column: "RequestId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Api.Migrations
{
    public partial class InitialMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<long>(type: "bigint", nullable: false),
                    DefectiveComponentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefectiveComponentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessRequest_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProcessingCharge = table.Column<double>(type: "float", nullable: false),
                    PackagingAndDeliveryCharge = table.Column<double>(type: "float", nullable: false),
                    DateOfDelivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessResponse_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessRequest_AppUserId",
                table: "ProcessRequest",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessResponse_AppUserId",
                table: "ProcessResponse",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessRequest");

            migrationBuilder.DropTable(
                name: "ProcessResponse");

            migrationBuilder.DropTable(
                name: "AppUser");
        }
    }
}

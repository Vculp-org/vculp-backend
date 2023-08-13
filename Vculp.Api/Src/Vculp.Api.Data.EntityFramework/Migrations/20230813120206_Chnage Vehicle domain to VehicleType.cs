using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vculp.Api.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class ChnageVehicledomaintoVehicleType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FareDetails_Vehicles_VehicleId",
                schema: "Vehicle",
                table: "FareDetails");

            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "Vehicle");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                schema: "Vehicle",
                table: "FareDetails",
                newName: "VehicleTypeId");

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                schema: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ClusterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_ClusterId",
                schema: "Vehicle",
                table: "VehicleTypes",
                column: "ClusterId",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_IsDeleted",
                schema: "Vehicle",
                table: "VehicleTypes",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_FareDetails_VehicleTypes_VehicleTypeId",
                schema: "Vehicle",
                table: "FareDetails",
                column: "VehicleTypeId",
                principalSchema: "Vehicle",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FareDetails_VehicleTypes_VehicleTypeId",
                schema: "Vehicle",
                table: "FareDetails");

            migrationBuilder.DropTable(
                name: "VehicleTypes",
                schema: "Vehicle");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                schema: "Vehicle",
                table: "FareDetails",
                newName: "VehicleId");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                schema: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClusterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    VehicleBodyType = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ClusterId",
                schema: "Vehicle",
                table: "Vehicles",
                column: "ClusterId",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_IsDeleted",
                schema: "Vehicle",
                table: "Vehicles",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_FareDetails_Vehicles_VehicleId",
                schema: "Vehicle",
                table: "FareDetails",
                column: "VehicleId",
                principalSchema: "Vehicle",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vculp.Api.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddnewVehicledomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Vehicle");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                schema: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    VehicleBodyType = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ClusterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "FareDetails",
                schema: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClusterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseFare = table.Column<double>(type: "float", nullable: false),
                    FreeKms = table.Column<double>(type: "float", nullable: false),
                    PerKmFare = table.Column<double>(type: "float", nullable: false),
                    MinPerKmFare = table.Column<double>(type: "float", nullable: false),
                    PerMinuteFare = table.Column<double>(type: "float", nullable: false),
                    CancellationFeePercentage = table.Column<double>(type: "float", nullable: false),
                    CancellationMaxAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FareDetails", x => new { x.VehicleId, x.ClusterId, x.City })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_FareDetails_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "Vehicle",
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FareDetails_ClusterId",
                schema: "Vehicle",
                table: "FareDetails",
                column: "ClusterId",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FareDetails",
                schema: "Vehicle");

            migrationBuilder.DropTable(
                name: "Vehicles",
                schema: "Vehicle");
        }
    }
}

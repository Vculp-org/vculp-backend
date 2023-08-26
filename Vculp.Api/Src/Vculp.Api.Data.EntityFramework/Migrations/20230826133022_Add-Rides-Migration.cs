using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vculp.Api.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddRidesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rides",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FromLatitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromLongitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToLatitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToLongitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    RequestedFare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedByUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedByUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rides", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rides");
        }
    }
}

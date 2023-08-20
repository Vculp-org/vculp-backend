using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vculp.Api.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddFareRecommendationdoamin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Fare");

            migrationBuilder.AddColumn<int>(
                name: "NoOfSeaters",
                schema: "Vehicle",
                table: "VehicleTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FareRecommendationDetails",
                schema: "Fare",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VehicleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    BaseFare = table.Column<double>(type: "float", nullable: false),
                    BaseFareFreeKms = table.Column<double>(type: "float", nullable: false),
                    ActualDistanceAfterFreeKms = table.Column<double>(type: "float", nullable: false),
                    DurationFare = table.Column<double>(type: "float", nullable: false),
                    MinimumDistanceFare = table.Column<double>(type: "float", nullable: false),
                    RecommendedDistanceFare = table.Column<double>(type: "float", nullable: false),
                    YourMinimumFare = table.Column<double>(type: "float", nullable: false),
                    YourRecommendedFare = table.Column<double>(type: "float", nullable: false),
                    TollCharges = table.Column<double>(type: "float", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ClusterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FareRecommendationDetails", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FareRecommendationDetails_ClusterId",
                schema: "Fare",
                table: "FareRecommendationDetails",
                column: "ClusterId",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_FareRecommendationDetails_IsDeleted",
                schema: "Fare",
                table: "FareRecommendationDetails",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FareRecommendationDetails",
                schema: "Fare");

            migrationBuilder.DropColumn(
                name: "NoOfSeaters",
                schema: "Vehicle",
                table: "VehicleTypes");
        }
    }
}

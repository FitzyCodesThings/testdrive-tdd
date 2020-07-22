using Microsoft.EntityFrameworkCore.Migrations;

namespace TestDriveTDD.Persistence.Migrations
{
    public partial class AddVehicleMake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Make",
                table: "Vehicle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MakeCarried",
                table: "Dealers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Make",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "MakeCarried",
                table: "Dealers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Datacar.Server.Migrations
{
    public partial class _20212012ChangeLicenseNumberTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LicenceNum",
                table: "Drivers",
                newName: "LicenseNum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LicenseNum",
                table: "Drivers",
                newName: "LicenceNum");
        }
    }
}

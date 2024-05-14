using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talabat.Repos.Migrations
{
    /// <inheritdoc />
    public partial class OrderModel_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discription",
                table: "DeliveryMethods",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "DelivesryTime",
                table: "DeliveryMethods",
                newName: "DeliveryTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "DeliveryMethods",
                newName: "Discription");

            migrationBuilder.RenameColumn(
                name: "DeliveryTime",
                table: "DeliveryMethods",
                newName: "DelivesryTime");
        }
    }
}

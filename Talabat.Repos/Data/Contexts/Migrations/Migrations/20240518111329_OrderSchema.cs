using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talabat.Repos.Migrations
{
    /// <inheritdoc />
    public partial class OrderSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "DeliveryMethods",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "DelliveryMethodId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelliveryMethodId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DeliveryMethods",
                newName: "ShortName");
        }
    }
}

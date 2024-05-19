using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talabat.Repos.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAddress_Coountry",
                table: "Orders",
                newName: "ShippingAddress_country");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAddress_country",
                table: "Orders",
                newName: "ShippingAddress_Coountry");
        }
    }
}

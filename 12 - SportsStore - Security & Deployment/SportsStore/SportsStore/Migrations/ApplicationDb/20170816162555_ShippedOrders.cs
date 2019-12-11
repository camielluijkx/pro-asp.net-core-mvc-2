using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Migrations.ApplicationDb
{
    /// <summary>
    /// Database migration created with command: dotnet ef migrations add ShippedOrders
    /// </summary>
    /// <remarks>
    /// Database can be removed with command: dotnet ef database drop --force
    /// Database can be updated with command: dotnet ef database update --context ApplicationDbContext
    /// </remarks>
    public partial class ShippedOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Shipped",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shipped",
                table: "Orders");
        }
    }
}
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstateWebsite.Migrations
{
    /// <inheritdoc />
    public partial class addMethodpayProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MethodPay",
                table: "Estates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MethodPay",
                table: "Estates");
        }
    }
}

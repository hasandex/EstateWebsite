using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstateWebsite.Migrations
{
    /// <inheritdoc />
    public partial class addSavePro1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaveEstate_Estates_EstateId",
                table: "SaveEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_SaveEstate_Users_UsersId",
                table: "SaveEstate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaveEstate",
                table: "SaveEstate");

            migrationBuilder.RenameTable(
                name: "SaveEstate",
                newName: "SaveEstates");

            migrationBuilder.RenameIndex(
                name: "IX_SaveEstate_UsersId",
                table: "SaveEstates",
                newName: "IX_SaveEstates_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_SaveEstate_EstateId",
                table: "SaveEstates",
                newName: "IX_SaveEstates_EstateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaveEstates",
                table: "SaveEstates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaveEstates_Estates_EstateId",
                table: "SaveEstates",
                column: "EstateId",
                principalTable: "Estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaveEstates_Users_UsersId",
                table: "SaveEstates",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaveEstates_Estates_EstateId",
                table: "SaveEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_SaveEstates_Users_UsersId",
                table: "SaveEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaveEstates",
                table: "SaveEstates");

            migrationBuilder.RenameTable(
                name: "SaveEstates",
                newName: "SaveEstate");

            migrationBuilder.RenameIndex(
                name: "IX_SaveEstates_UsersId",
                table: "SaveEstate",
                newName: "IX_SaveEstate_UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_SaveEstates_EstateId",
                table: "SaveEstate",
                newName: "IX_SaveEstate_EstateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaveEstate",
                table: "SaveEstate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaveEstate_Estates_EstateId",
                table: "SaveEstate",
                column: "EstateId",
                principalTable: "Estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaveEstate_Users_UsersId",
                table: "SaveEstate",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

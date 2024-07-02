using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstateWebsite.Migrations
{
    /// <inheritdoc />
    public partial class updateClassName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeImages");

            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Governorate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    NFloor = table.Column<int>(type: "int", nullable: false),
                    NRoom = table.Column<int>(type: "int", nullable: false),
                    NBedroom = table.Column<int>(type: "int", nullable: false),
                    NBath = table.Column<int>(type: "int", nullable: false),
                    NLivingRoom = table.Column<int>(type: "int", nullable: false),
                    NReceptionRoom = table.Column<int>(type: "int", nullable: false),
                    NBalcone = table.Column<int>(type: "int", nullable: false),
                    NGarage = table.Column<int>(type: "int", nullable: false),
                    NKitchen = table.Column<int>(type: "int", nullable: false),
                    NFoodRoom = table.Column<int>(type: "int", nullable: false),
                    NDepot = table.Column<int>(type: "int", nullable: false),
                    Cover = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ExtraFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ForRent = table.Column<bool>(type: "bit", nullable: false),
                    ForSale = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstateImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstateImages_Estates_EstateId",
                        column: x => x.EstateId,
                        principalTable: "Estates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstateImages_EstateId",
                table: "EstateImages",
                column: "EstateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstateImages");

            migrationBuilder.DropTable(
                name: "Estates");

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cover = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ExtraFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForRent = table.Column<bool>(type: "bit", nullable: false),
                    ForSale = table.Column<bool>(type: "bit", nullable: false),
                    Governorate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    NBalcone = table.Column<int>(type: "int", nullable: false),
                    NBath = table.Column<int>(type: "int", nullable: false),
                    NBedroom = table.Column<int>(type: "int", nullable: false),
                    NDepot = table.Column<int>(type: "int", nullable: false),
                    NFloor = table.Column<int>(type: "int", nullable: false),
                    NFoodRoom = table.Column<int>(type: "int", nullable: false),
                    NGarage = table.Column<int>(type: "int", nullable: false),
                    NKitchen = table.Column<int>(type: "int", nullable: false),
                    NLivingRoom = table.Column<int>(type: "int", nullable: false),
                    NReceptionRoom = table.Column<int>(type: "int", nullable: false),
                    NRoom = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeId = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeImages_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeImages_HomeId",
                table: "HomeImages",
                column: "HomeId");
        }
    }
}

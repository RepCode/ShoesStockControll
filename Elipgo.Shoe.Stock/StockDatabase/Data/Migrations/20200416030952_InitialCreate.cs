using Microsoft.EntityFrameworkCore.Migrations;

namespace Elipgo.ShoeStock.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true),
                    total_in_shelf = table.Column<string>(nullable: true),
                    total_in_vault = table.Column<string>(nullable: true),
                    store_id = table.Column<string>(nullable: true),
                    StoreId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.id);
                    table.ForeignKey(
                        name: "FK_Articles_Stores_StoreId1",
                        column: x => x.StoreId1,
                        principalTable: "Stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_StoreId1",
                table: "Articles",
                column: "StoreId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}

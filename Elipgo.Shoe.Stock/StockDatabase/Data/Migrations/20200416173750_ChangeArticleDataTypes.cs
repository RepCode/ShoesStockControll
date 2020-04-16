using Microsoft.EntityFrameworkCore.Migrations;

namespace Elipgo.ShoeStock.Database.Migrations
{
    public partial class ChangeArticleDataTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Stores_StoreId1",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_StoreId1",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "StoreId1",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "total_in_vault",
                table: "Articles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "total_in_shelf",
                table: "Articles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "store_id",
                table: "Articles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "price",
                table: "Articles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_store_id",
                table: "Articles",
                column: "store_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Stores_store_id",
                table: "Articles",
                column: "store_id",
                principalTable: "Stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Stores_store_id",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_store_id",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "total_in_vault",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "total_in_shelf",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "store_id",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "price",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<int>(
                name: "StoreId1",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_StoreId1",
                table: "Articles",
                column: "StoreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Stores_StoreId1",
                table: "Articles",
                column: "StoreId1",
                principalTable: "Stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

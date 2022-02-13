using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class CardImageCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardImage_Card_CardId",
                table: "CardImage");

            migrationBuilder.AddForeignKey(
                name: "FK_CardImage_Card_CardId",
                table: "CardImage",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardImage_Card_CardId",
                table: "CardImage");

            migrationBuilder.AddForeignKey(
                name: "FK_CardImage_Card_CardId",
                table: "CardImage",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id");
        }
    }
}

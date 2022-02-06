using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangeDefaultValueOfEasinessFactorInCardEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "EasinessFactor",
                table: "Card",
                type: "float",
                nullable: false,
                defaultValue: 1.3,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 2.5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "EasinessFactor",
                table: "Card",
                type: "float",
                nullable: false,
                defaultValue: 2.5,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 1.3);
        }
    }
}

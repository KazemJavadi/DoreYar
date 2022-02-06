using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangeEasinessFactorTypeInCardEntityFromDoubleToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "EasinessFactor",
                table: "Card",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 1.3m,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 1.3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "EasinessFactor",
                table: "Card",
                type: "float",
                nullable: false,
                defaultValue: 1.3,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 1.3m);
        }
    }
}

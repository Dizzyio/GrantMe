using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grant_Me.Migrations
{
    /// <inheritdoc />
    public partial class AddIsBusinessAndIsNonProfit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessStructure",
                table: "UserResponses");

            migrationBuilder.AlterColumn<string>(
                name: "CharityNumber",
                table: "UserResponses",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "BusinessRevenue",
                table: "UserResponses",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessName",
                table: "UserResponses",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<bool>(
                name: "IsBusiness",
                table: "UserResponses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBusiness",
                table: "UserResponses");

            migrationBuilder.AlterColumn<string>(
                name: "CharityNumber",
                table: "UserResponses",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BusinessRevenue",
                table: "UserResponses",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessName",
                table: "UserResponses",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessStructure",
                table: "UserResponses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

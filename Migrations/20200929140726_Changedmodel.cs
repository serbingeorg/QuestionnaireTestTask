using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestionnareTestTask.Migrations
{
    public partial class Changedmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "Questionnaires");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Questionnaires",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Questionnaires",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Questionnaires",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

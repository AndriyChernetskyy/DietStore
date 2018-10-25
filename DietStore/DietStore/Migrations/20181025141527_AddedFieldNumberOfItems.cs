using Microsoft.EntityFrameworkCore.Migrations;

namespace DietStore.Migrations
{
    public partial class AddedFieldNumberOfItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfItems",
                table: "Purchased",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfItems",
                table: "Purchased");
        }
    }
}

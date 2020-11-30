using Microsoft.EntityFrameworkCore.Migrations;

namespace IGI.Migrations
{
    public partial class messageaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddresseeId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddresseeId",
                table: "Messages");
        }
    }
}

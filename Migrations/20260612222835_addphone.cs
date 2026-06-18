using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News_Project.Migrations
{
    /// <inheritdoc />
    public partial class addphone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "phone",
                table: "ContactUs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone",
                table: "ContactUs");
        }
    }
}

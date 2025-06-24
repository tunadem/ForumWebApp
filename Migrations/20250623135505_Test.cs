using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserName",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zad.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddChatSessionNameAndCitationIndexFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ChatSessions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ChatSessions");
        }
    }
}

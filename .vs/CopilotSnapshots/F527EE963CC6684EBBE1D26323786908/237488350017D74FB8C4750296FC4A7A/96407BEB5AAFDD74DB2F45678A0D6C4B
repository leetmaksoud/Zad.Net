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
            migrationBuilder.DropIndex(
                name: "IX_Citations_MessageId_DocumentId_ReferenceText",
                table: "Citations");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ChatSessions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citations_MessageId_DocumentId",
                table: "Citations",
                columns: new[] { "MessageId", "DocumentId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Citations_MessageId_DocumentId",
                table: "Citations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ChatSessions");

            migrationBuilder.CreateIndex(
                name: "IX_Citations_MessageId_DocumentId_ReferenceText",
                table: "Citations",
                columns: new[] { "MessageId", "DocumentId", "ReferenceText" },
                unique: true);
        }
    }
}

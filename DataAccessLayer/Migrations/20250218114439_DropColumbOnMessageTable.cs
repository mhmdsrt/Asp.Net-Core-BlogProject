using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class DropColumbOnMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageReceiver",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "MessageSender",
                table: "Messages",
                newName: "MessageReceiverMail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageReceiverMail",
                table: "Messages",
                newName: "MessageSender");

            migrationBuilder.AddColumn<string>(
                name: "MessageReceiver",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

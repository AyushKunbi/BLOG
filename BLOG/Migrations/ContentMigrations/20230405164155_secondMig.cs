using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLOG.Migrations.ContentMigrations
{
    /// <inheritdoc />
    public partial class secondMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisLikeCount",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisLikeCount",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Contents");
        }
    }
}

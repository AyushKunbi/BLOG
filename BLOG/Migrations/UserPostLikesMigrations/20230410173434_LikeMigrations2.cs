using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLOG.Migrations.UserPostLikesMigrations
{
    /// <inheritdoc />
    public partial class LikeMigrations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId_PostId",
                table: "Likes",
                columns: new[] { "UserId", "PostId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Likes_UserId_PostId",
                table: "Likes");
        }
    }
}

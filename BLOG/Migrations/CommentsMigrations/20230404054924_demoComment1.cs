using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLOG.Migrations.CommentsMigrations
{
    /// <inheritdoc />
    public partial class demoComment1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Like = table.Column<int>(type: "int", nullable: false),
                    Dislike = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");
        }
    }
}

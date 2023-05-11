using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog_project.Migrations
{
    /// <inheritdoc />
    public partial class Blog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83F3AB8697E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Coments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    coment = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    post_id = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Coments__3213E83F68E19F79", x => x.id);
                    table.ForeignKey(
                        name: "FK_Coments_Users_post_id",
                        column: x => x.post_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    post_title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    post_body = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Post__3213E83F3D5DDCB9", x => x.id);
                    table.ForeignKey(
                        name: "FK_Post_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coments_post_id",
                table: "Coments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_user_id",
                table: "Post",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coments");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

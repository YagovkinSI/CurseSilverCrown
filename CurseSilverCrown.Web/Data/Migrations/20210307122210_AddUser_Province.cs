using Microsoft.EntityFrameworkCore.Migrations;

namespace CurseSilverCrown.Web.Data.Migrations
{
    public partial class AddUser_Province : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Province",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Province", x => new { x.ProvinceId, x.UserId });
                    table.ForeignKey(
                        name: "FK_User_Province_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Province_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Province_ProvinceId",
                table: "User_Province",
                column: "ProvinceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Province_UserId",
                table: "User_Province",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Province");
        }
    }
}

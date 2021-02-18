using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieShop.Infrastructure.Migrations
{
    public partial class UpdateMovieCastTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_Cast_Character",
                table: "MovieCast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast");

            migrationBuilder.DropIndex(
                name: "IX_MovieCast_Character",
                table: "MovieCast");

            migrationBuilder.DropIndex(
                name: "IX_MovieCast_MovieId",
                table: "MovieCast");

            migrationBuilder.AlterColumn<string>(
                name: "Character",
                table: "MovieCast",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Cast",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast",
                columns: new[] { "MovieId", "CastId", "Character" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_CastId",
                table: "MovieCast",
                column: "CastId");

            migrationBuilder.CreateIndex(
                name: "IX_Cast_MovieId",
                table: "Cast",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cast_Movie_MovieId",
                table: "Cast",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cast_Movie_MovieId",
                table: "Cast");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast");

            migrationBuilder.DropIndex(
                name: "IX_MovieCast_CastId",
                table: "MovieCast");

            migrationBuilder.DropIndex(
                name: "IX_Cast_MovieId",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Cast");

            migrationBuilder.AlterColumn<int>(
                name: "Character",
                table: "MovieCast",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCast",
                table: "MovieCast",
                columns: new[] { "CastId", "MovieId" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_Character",
                table: "MovieCast",
                column: "Character");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_MovieId",
                table: "MovieCast",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_Cast_Character",
                table: "MovieCast",
                column: "Character",
                principalTable: "Cast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

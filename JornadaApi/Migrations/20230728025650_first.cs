using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaApi.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Depoiementos",
                table: "Depoiementos");

            migrationBuilder.RenameTable(
                name: "Depoiementos",
                newName: "Depoimentos");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Depoimentos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Depoimentos",
                table: "Depoimentos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Depoimentos",
                table: "Depoimentos");

            migrationBuilder.RenameTable(
                name: "Depoimentos",
                newName: "Depoiementos");

            migrationBuilder.UpdateData(
                table: "Depoiementos",
                keyColumn: "Foto",
                keyValue: null,
                column: "Foto",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Depoiementos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Depoiementos",
                table: "Depoiementos",
                column: "Id");
        }
    }
}

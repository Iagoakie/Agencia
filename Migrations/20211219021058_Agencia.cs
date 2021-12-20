using Microsoft.EntityFrameworkCore.Migrations;

namespace Agencia1.Migrations
{
    public partial class Agencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestinoUser",
                columns: table => new
                {
                    Id_Destino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    País = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSaida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataChegada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinoUser", x => x.Id_Destino);
                });

            migrationBuilder.CreateTable(
                name: "NovoUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinoUserId_Destino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovoUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovoUsers_DestinoUser_DestinoUserId_Destino",
                        column: x => x.DestinoUserId_Destino,
                        principalTable: "DestinoUser",
                        principalColumn: "Id_Destino",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NovoUsers_DestinoUserId_Destino",
                table: "NovoUsers",
                column: "DestinoUserId_Destino");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NovoUsers");

            migrationBuilder.DropTable(
                name: "DestinoUser");
        }
    }
}

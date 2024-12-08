using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class IniticalCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    FolhaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FuncionarioId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Mes = table.Column<int>(type: "INTEGER", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.FolhaId);
                    table.ForeignKey(
                        name: "FK_Folhas_Funcionarios_FuncionarioId1",
                        column: x => x.FuncionarioId1,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_FuncionarioId1",
                table: "Folhas",
                column: "FuncionarioId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folhas");
        }
    }
}

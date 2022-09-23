using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyInsuranceAPI.Migrations
{
    public partial class Adicionaritenseseguros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorEstimado = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DataAquisicaoItem = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Seguros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ValorTotal = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ValorParcela = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    QuantidadeParcelas = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ItemId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguros_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seguros_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_UsuarioId",
                table: "Itens",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguros_ItemId",
                table: "Seguros",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguros_UsuarioId",
                table: "Seguros",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguros");

            migrationBuilder.DropTable(
                name: "Itens");
        }
    }
}

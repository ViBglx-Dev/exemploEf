using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExemploEF.Migrations
{
    /// <inheritdoc />
    public partial class produtoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produto_Categorias_categoriaid",
                table: "produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produto",
                table: "produto");

            migrationBuilder.RenameTable(
                name: "produto",
                newName: "Produtos");

            migrationBuilder.RenameIndex(
                name: "IX_produto_categoriaid",
                table: "Produtos",
                newName: "IX_Produtos_categoriaid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "produtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_categoriaid",
                table: "Produtos",
                column: "categoriaid",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_categoriaid",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "produto");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_categoriaid",
                table: "produto",
                newName: "IX_produto_categoriaid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produto",
                table: "produto",
                column: "produtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_produto_Categorias_categoriaid",
                table: "produto",
                column: "categoriaid",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

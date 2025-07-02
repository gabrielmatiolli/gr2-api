using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gr2_api.Migrations
{
    /// <inheritdoc />
    public partial class ComponenteAndRelationshipWithEquipamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponenteEquipamento",
                columns: table => new
                {
                    ComponentesId = table.Column<int>(type: "int", nullable: false),
                    EquipamentosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponenteEquipamento", x => new { x.ComponentesId, x.EquipamentosId });
                    table.ForeignKey(
                        name: "FK_ComponenteEquipamento_Componente_ComponentesId",
                        column: x => x.ComponentesId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponenteEquipamento_Equipamentos_EquipamentosId",
                        column: x => x.EquipamentosId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponenteEquipamento_EquipamentosId",
                table: "ComponenteEquipamento",
                column: "EquipamentosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponenteEquipamento");

            migrationBuilder.DropTable(
                name: "Componente");
        }
    }
}

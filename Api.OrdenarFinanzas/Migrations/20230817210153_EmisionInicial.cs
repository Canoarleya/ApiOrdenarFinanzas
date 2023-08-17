using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.OrdenarFinanzas.Migrations
{
    /// <inheritdoc />
    public partial class EmisionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdCliente = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombresCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido1Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido2Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NroDocCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelContactoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Periodicidad",
                columns: table => new
                {
                    IdPeriodicidad = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionPeriodicidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodicidad", x => x.IdPeriodicidad);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoGastoFijo",
                columns: table => new
                {
                    IdTipoGastoFijo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionTipoGastoFijo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoGastoFijo", x => x.IdTipoGastoFijo);
                    table.ForeignKey(
                        name: "FK_TipoGastoFijo_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GastoFijo",
                columns: table => new
                {
                    IdGastoFijo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionGastoFijo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoEstimado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdPeriodicidad = table.Column<long>(type: "bigint", nullable: false),
                    PeriodicidadIdPeriodicidad = table.Column<long>(type: "bigint", nullable: true),
                    IdTipoGastoFijo = table.Column<long>(type: "bigint", nullable: false),
                    TipoGastoFijoIdTipoGastoFijo = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastoFijo", x => x.IdGastoFijo);
                    table.ForeignKey(
                        name: "FK_GastoFijo_Periodicidad_PeriodicidadIdPeriodicidad",
                        column: x => x.PeriodicidadIdPeriodicidad,
                        principalTable: "Periodicidad",
                        principalColumn: "IdPeriodicidad");
                    table.ForeignKey(
                        name: "FK_GastoFijo_TipoGastoFijo_TipoGastoFijoIdTipoGastoFijo",
                        column: x => x.TipoGastoFijoIdTipoGastoFijo,
                        principalTable: "TipoGastoFijo",
                        principalColumn: "IdTipoGastoFijo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GastoFijo_PeriodicidadIdPeriodicidad",
                table: "GastoFijo",
                column: "PeriodicidadIdPeriodicidad");

            migrationBuilder.CreateIndex(
                name: "IX_GastoFijo_TipoGastoFijoIdTipoGastoFijo",
                table: "GastoFijo",
                column: "TipoGastoFijoIdTipoGastoFijo");

            migrationBuilder.CreateIndex(
                name: "IX_TipoGastoFijo_UserId",
                table: "TipoGastoFijo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "GastoFijo");

            migrationBuilder.DropTable(
                name: "Periodicidad");

            migrationBuilder.DropTable(
                name: "TipoGastoFijo");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}

using System;
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
                name: "TipoPago",
                columns: table => new
                {
                    IdTipoPago = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionTipoPago = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPago", x => x.IdTipoPago);
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
                name: "MetaAhorro",
                columns: table => new
                {
                    IdMetaAhorro = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionMetaAhorro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoObjetivo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaseInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoPeriodico = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdPeriodicidad = table.Column<long>(type: "bigint", nullable: false),
                    FechaProyectadaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaAhorro", x => x.IdMetaAhorro);
                    table.ForeignKey(
                        name: "FK_MetaAhorro_Periodicidad_IdPeriodicidad",
                        column: x => x.IdPeriodicidad,
                        principalTable: "Periodicidad",
                        principalColumn: "IdPeriodicidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    IdPago = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTipoPago = table.Column<long>(type: "bigint", nullable: false),
                    IdSubtipo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pago_TipoPago_IdTipoPago",
                        column: x => x.IdTipoPago,
                        principalTable: "TipoPago",
                        principalColumn: "IdTipoPago",
                        onDelete: ReferentialAction.Cascade);
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
                    IdTipoGastoFijo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GastoFijo", x => x.IdGastoFijo);
                    table.ForeignKey(
                        name: "FK_GastoFijo_Periodicidad_IdPeriodicidad",
                        column: x => x.IdPeriodicidad,
                        principalTable: "Periodicidad",
                        principalColumn: "IdPeriodicidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GastoFijo_TipoGastoFijo_IdTipoGastoFijo",
                        column: x => x.IdTipoGastoFijo,
                        principalTable: "TipoGastoFijo",
                        principalColumn: "IdTipoGastoFijo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GastoFijo_IdPeriodicidad",
                table: "GastoFijo",
                column: "IdPeriodicidad");

            migrationBuilder.CreateIndex(
                name: "IX_GastoFijo_IdTipoGastoFijo",
                table: "GastoFijo",
                column: "IdTipoGastoFijo");

            migrationBuilder.CreateIndex(
                name: "IX_MetaAhorro_IdPeriodicidad",
                table: "MetaAhorro",
                column: "IdPeriodicidad");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_IdTipoPago",
                table: "Pago",
                column: "IdTipoPago");

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
                name: "MetaAhorro");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "TipoGastoFijo");

            migrationBuilder.DropTable(
                name: "Periodicidad");

            migrationBuilder.DropTable(
                name: "TipoPago");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}

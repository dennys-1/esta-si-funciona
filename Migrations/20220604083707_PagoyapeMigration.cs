using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace hostal.Migrations
{
    public partial class PagoyapeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_pagoyape",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Capturayape = table.Column<string>(type: "text", nullable: true),
                    MontoTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    UserID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_pagoyape", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_orderyape",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    pagoId = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_orderyape", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_orderyape_t_pagoyape_pagoId",
                        column: x => x.pagoId,
                        principalTable: "t_pagoyape",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_order_detailyape",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductoId = table.Column<int>(type: "integer", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    pedidoID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_order_detailyape", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_order_detailyape_t_orderyape_pedidoID",
                        column: x => x.pedidoID,
                        principalTable: "t_orderyape",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_order_detailyape_t_product_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "t_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_order_detailyape_pedidoID",
                table: "t_order_detailyape",
                column: "pedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_t_order_detailyape_ProductoId",
                table: "t_order_detailyape",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_t_orderyape_pagoId",
                table: "t_orderyape",
                column: "pagoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_order_detailyape");

            migrationBuilder.DropTable(
                name: "t_orderyape");

            migrationBuilder.DropTable(
                name: "t_pagoyape");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boundaries.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    DiscountTypeId = table.Column<int>(nullable: false),
                    DiscountValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiscountType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    IsEmployee = table.Column<bool>(nullable: false),
                    IsAffiliated = table.Column<bool>(nullable: false),
                    AffiliatedOnUtc = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_ItemType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillDiscount",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false),
                    DiscountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDiscount", x => new { x.BillId, x.DiscountId });
                    table.ForeignKey(
                        name: "FK_BillDiscount_Discount_BillId",
                        column: x => x.BillId,
                        principalTable: "Discount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillDiscount_Bill_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillItem",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SubTotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillItem", x => new { x.BillId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_BillItem_Item_BillId",
                        column: x => x.BillId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillItem_Bill_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Bill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "CreatedOnUtc", "Description", "DiscountType", "DiscountTypeId", "DiscountValue", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 8, 18, 10, 1, 566, DateTimeKind.Local).AddTicks(5512), "10% de descuento para clientes afiliados", 1, 1, 10.00m, "10% Afiliados" },
                    { 2, new DateTime(2021, 5, 8, 18, 10, 1, 567, DateTimeKind.Local).AddTicks(3355), "30% de descuento para empleados", 1, 1, 30.00m, "30% Empleados" },
                    { 3, new DateTime(2021, 5, 8, 18, 10, 1, 567, DateTimeKind.Local).AddTicks(3367), "10% de descuento para clientes afiliados", 1, 1, 10.00m, "5% 2 años con nosotros" }
                });

            migrationBuilder.InsertData(
                table: "ItemType",
                columns: new[] { "Id", "CreatedOnUtc", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 8, 22, 10, 1, 558, DateTimeKind.Utc).AddTicks(953), "Comestible" },
                    { 2, new DateTime(2021, 5, 8, 22, 10, 1, 558, DateTimeKind.Utc).AddTicks(1015), "Limpieza" },
                    { 3, new DateTime(2021, 5, 8, 22, 10, 1, 558, DateTimeKind.Utc).AddTicks(1016), "Ropa" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AffiliatedOnUtc", "CreatedOnUtc", "IsAffiliated", "IsEmployee", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 8, 22, 10, 1, 548, DateTimeKind.Utc).AddTicks(7018), new DateTime(2021, 5, 8, 22, 10, 1, 548, DateTimeKind.Utc).AddTicks(7670), true, false, "Juan Pérez" },
                    { 2, new DateTime(2021, 5, 8, 22, 10, 1, 548, DateTimeKind.Utc).AddTicks(8217), new DateTime(2021, 5, 8, 22, 10, 1, 548, DateTimeKind.Utc).AddTicks(8229), true, true, "María Magdalena" },
                    { 3, new DateTime(2021, 5, 8, 22, 10, 1, 548, DateTimeKind.Utc).AddTicks(8237), new DateTime(2021, 5, 8, 22, 10, 1, 548, DateTimeKind.Utc).AddTicks(8238), false, false, "Pedro Almonte" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "CreatedOnUtc", "Name", "TypeId", "UnitPrice" },
                values: new object[] { 1, new DateTime(2021, 5, 8, 22, 10, 1, 559, DateTimeKind.Utc).AddTicks(8398), "Manzana", 1, 24.99m });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "CreatedOnUtc", "Name", "TypeId", "UnitPrice" },
                values: new object[] { 3, new DateTime(2021, 5, 8, 22, 10, 1, 559, DateTimeKind.Utc).AddTicks(8468), "Mistolin", 2, 84.99m });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "CreatedOnUtc", "Name", "TypeId", "UnitPrice" },
                values: new object[] { 2, new DateTime(2021, 5, 8, 22, 10, 1, 559, DateTimeKind.Utc).AddTicks(8465), "Pantalon", 3, 299.99m });

            migrationBuilder.CreateIndex(
                name: "IX_Bill_UserId",
                table: "Bill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDiscount_DiscountId",
                table: "BillDiscount",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_BillItem_ItemId",
                table: "BillItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_TypeId",
                table: "Item",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDiscount");

            migrationBuilder.DropTable(
                name: "BillItem");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

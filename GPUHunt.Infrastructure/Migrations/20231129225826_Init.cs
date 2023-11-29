using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPUHunt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subvendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subvendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GraphicCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    SubvendorId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraphicCards_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GraphicCards_Subvendors_SubvendorId",
                        column: x => x.SubvendorId,
                        principalTable: "Subvendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GraphicCards_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GraphicCardId = table.Column<int>(type: "int", nullable: false),
                    MoreleActualPrice = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    XKomActualPrice = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    IsPriceEqual = table.Column<bool>(type: "bit", nullable: false),
                    CrawlTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MoreleLowestPriceEver = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    MoreleLowestPriceEverCrawlDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    XkomLowestPriceEver = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    XkomLowestPriceEverCrawlDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MoreleHighestPriceEver = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    MoreleHighestPriceEverCrawlDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    XkomHighestPriceEver = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    XkomHighestPriceEverCrawlDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_GraphicCards_GraphicCardId",
                        column: x => x.GraphicCardId,
                        principalTable: "GraphicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_GraphicCards_AccountId",
                table: "GraphicCards",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GraphicCards_SubvendorId",
                table: "GraphicCards",
                column: "SubvendorId");

            migrationBuilder.CreateIndex(
                name: "IX_GraphicCards_VendorId",
                table: "GraphicCards",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_GraphicCardId",
                table: "Prices",
                column: "GraphicCardId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "GraphicCards");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Subvendors");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

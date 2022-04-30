using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamexApp.Data.Migrations
{
    public partial class FirstMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 252, DateTimeKind.Utc).AddTicks(2880)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 252, DateTimeKind.Utc).AddTicks(5356)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 262, DateTimeKind.Utc).AddTicks(9783)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 263, DateTimeKind.Utc).AddTicks(166)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 255, DateTimeKind.Utc).AddTicks(821)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 255, DateTimeKind.Utc).AddTicks(1418)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 261, DateTimeKind.Utc).AddTicks(8211)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 261, DateTimeKind.Utc).AddTicks(8623)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 264, DateTimeKind.Utc).AddTicks(230)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 264, DateTimeKind.Utc).AddTicks(688)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 266, DateTimeKind.Utc).AddTicks(5932)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 266, DateTimeKind.Utc).AddTicks(7257)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsSections_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 268, DateTimeKind.Utc).AddTicks(5323)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 268, DateTimeKind.Utc).AddTicks(5739)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 269, DateTimeKind.Utc).AddTicks(8920)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 269, DateTimeKind.Utc).AddTicks(9320)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sliders_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 271, DateTimeKind.Utc).AddTicks(526)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 271, DateTimeKind.Utc).AddTicks(930)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryBrands_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinWeight = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DeliveryTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 260, DateTimeKind.Utc).AddTicks(8294)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 28, 22, 53, 37, 260, DateTimeKind.Utc).AddTicks(8727)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryPrices_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryPrices_DeliveryTypes_DeliveryTypeId",
                        column: x => x.DeliveryTypeId,
                        principalTable: "DeliveryTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LanguageId",
                table: "Countries",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryBrands_BrandId",
                table: "CountryBrands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryBrands_CountryId",
                table: "CountryBrands",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPrices_CountryId",
                table: "DeliveryPrices",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPrices_DeliveryTypeId",
                table: "DeliveryPrices",
                column: "DeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTypes_LanguageId",
                table: "DeliveryTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_News_LanguageId",
                table: "News",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsSections_LanguageId",
                table: "NewsSections",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_LanguageId",
                table: "Services",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_LanguageId",
                table: "Sliders",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_LanguageId",
                table: "Videos",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryBrands");

            migrationBuilder.DropTable(
                name: "DeliveryPrices");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "NewsSections");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "DeliveryTypes");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}

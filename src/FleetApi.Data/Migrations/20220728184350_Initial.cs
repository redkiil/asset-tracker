using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetApi.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Badge = table.Column<short>(type: "smallint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Badge);
                    table.UniqueConstraint("AK_employees_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employees_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fleet = table.Column<short>(type: "smallint", nullable: false),
                    Model = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelYear = table.Column<short>(type: "smallint", nullable: false),
                    Position = table.Column<string>(type: "JSON", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastime = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2022, 7, 28, 18, 43, 50, 201, DateTimeKind.Utc).AddTicks(3612)),
                    EmployeeBadge = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)9999),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<string>(type: "JSON", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_equipments_employees_EmployeeBadge",
                        column: x => x.EmployeeBadge,
                        principalTable: "employees",
                        principalColumn: "Badge",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipments_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
            migrationBuilder.InsertData(
                table: "groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { 0, "Default" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Badge", "GroupId", "Name" },
                values: new object[] { (short)9999, 1, "Generic" });

            migrationBuilder.CreateIndex(
                name: "IX_employees_GroupId",
                table: "employees",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_equipments_EmployeeBadge",
                table: "equipments",
                column: "EmployeeBadge");

            migrationBuilder.CreateIndex(
                name: "IX_equipments_GroupId",
                table: "equipments",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipments");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "groups");
        }
    }
}

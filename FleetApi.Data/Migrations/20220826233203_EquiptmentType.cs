using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetApi.Data.Migrations
{
    public partial class EquiptmentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<DateTime>(
                name: "Lastime",
                table: "equipments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 26, 23, 32, 3, 608, DateTimeKind.Utc).AddTicks(3369),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 7, 28, 18, 43, 50, 201, DateTimeKind.Utc).AddTicks(3612));

            migrationBuilder.AddColumn<string>(
                name: "EquipType",
                table: "equipments",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipType",
                table: "equipments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Lastime",
                table: "equipments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 28, 18, 43, 50, 201, DateTimeKind.Utc).AddTicks(3612),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 8, 26, 23, 32, 3, 608, DateTimeKind.Utc).AddTicks(3369));

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Badge", "GroupId", "Name" },
                values: new object[] { (short)9999, 1, "Generic" });

            migrationBuilder.InsertData(
                table: "groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { -1, "Default" });
        }
    }
}

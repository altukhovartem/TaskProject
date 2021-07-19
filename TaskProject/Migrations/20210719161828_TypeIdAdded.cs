using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskProject.Migrations
{
    public partial class TypeIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "TypeId" },
                values: new object[] { new DateTime(2021, 7, 19, 19, 18, 28, 370, DateTimeKind.Local).AddTicks(8026), 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "TypeId" },
                values: new object[] { new DateTime(2021, 7, 19, 19, 18, 28, 372, DateTimeKind.Local).AddTicks(278), 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "TypeId" },
                values: new object[] { new DateTime(2021, 7, 19, 19, 18, 28, 372, DateTimeKind.Local).AddTicks(333), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TypeId",
                table: "Tasks",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TypeId",
                table: "Tasks",
                column: "TypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TypeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TypeId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedTime", "Type" },
                values: new object[] { new DateTime(2021, 7, 19, 19, 12, 57, 810, DateTimeKind.Local).AddTicks(1639), 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedTime", "Type" },
                values: new object[] { new DateTime(2021, 7, 19, 19, 12, 57, 812, DateTimeKind.Local).AddTicks(4437), 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedTime", "Type" },
                values: new object[] { new DateTime(2021, 7, 19, 19, 12, 57, 812, DateTimeKind.Local).AddTicks(4631), 3 });
        }
    }
}

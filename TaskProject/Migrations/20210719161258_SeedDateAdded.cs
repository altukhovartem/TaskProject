using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskProject.Migrations
{
    public partial class SeedDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Task" },
                    { 2, "Bug" },
                    { 3, "Change Request" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedTime", "Title", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 19, 19, 12, 57, 810, DateTimeKind.Local).AddTicks(1639), "First Task", 1 },
                    { 2, new DateTime(2021, 7, 19, 19, 12, 57, 812, DateTimeKind.Local).AddTicks(4437), "Second Task", 2 },
                    { 3, new DateTime(2021, 7, 19, 19, 12, 57, 812, DateTimeKind.Local).AddTicks(4631), "Third Task", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Tasks",
                type: "int",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}

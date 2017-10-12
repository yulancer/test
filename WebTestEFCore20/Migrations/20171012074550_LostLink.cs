using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebTestEFCore20.Migrations
{
    public partial class LostLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountOwner_OwnerId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_OwnerId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountOwner",
                table: "AccountOwner");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AccountOwner");

            migrationBuilder.DropColumn(
                name: "LegalType",
                table: "AccountOwner");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AccountOwner");

            migrationBuilder.RenameTable(
                name: "AccountOwner",
                newName: "Persons");

            migrationBuilder.RenameColumn(
                name: "Person_Name",
                table: "Persons",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Accounts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LegalEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LegalType = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "AccountOwner");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AccountOwner",
                newName: "Person_Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AccountOwner",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AccountOwner",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LegalType",
                table: "AccountOwner",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AccountOwner",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountOwner",
                table: "AccountOwner",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OwnerId",
                table: "Accounts",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountOwner_OwnerId",
                table: "Accounts",
                column: "OwnerId",
                principalTable: "AccountOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

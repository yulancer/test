using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebTestEFCore20.Migrations
{
    public partial class LostLink3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_LegalEntities_LegalEntityId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Persons_PersonId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "LegalEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_LegalEntityId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PersonId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "LegalEntityId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Accounts");

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
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AccountOwner",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LegalType",
                table: "AccountOwner",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AccountOwner",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Accounts",
                type: "INTEGER",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "OwnerId",
                table: "Accounts");

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

            migrationBuilder.AddColumn<int>(
                name: "LegalEntityId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "LegalEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LegalType = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_LegalEntityId",
                table: "Accounts",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PersonId",
                table: "Accounts",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_LegalEntities_LegalEntityId",
                table: "Accounts",
                column: "LegalEntityId",
                principalTable: "LegalEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Persons_PersonId",
                table: "Accounts",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

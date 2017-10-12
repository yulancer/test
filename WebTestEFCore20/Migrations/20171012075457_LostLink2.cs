using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebTestEFCore20.Migrations
{
    public partial class LostLink2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "LegalEntityId",
                table: "Accounts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Accounts",
                type: "INTEGER",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_LegalEntities_LegalEntityId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Persons_PersonId",
                table: "Accounts");

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

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);
        }
    }
}

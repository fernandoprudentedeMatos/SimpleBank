using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBank.API.Migrations
{
    public partial class SimpleBankInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferMoneyOperations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    AccountSourceId = table.Column<string>(nullable: true),
                    AccountDestinyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferMoneyOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferMoneyOperations_Accounts_AccountDestinyId",
                        column: x => x.AccountDestinyId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferMoneyOperations_Accounts_AccountSourceId",
                        column: x => x.AccountSourceId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransferMoneyOperations_AccountDestinyId",
                table: "TransferMoneyOperations",
                column: "AccountDestinyId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferMoneyOperations_AccountSourceId",
                table: "TransferMoneyOperations",
                column: "AccountSourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferMoneyOperations");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}

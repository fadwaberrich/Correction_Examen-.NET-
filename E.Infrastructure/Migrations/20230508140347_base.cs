using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banques",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banques", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DAB",
                columns: table => new
                {
                    DABId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Localisation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DAB", x => x.DABId);
                });

            migrationBuilder.CreateTable(
                name: "Comptes",
                columns: table => new
                {
                    NumeroCompte = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Proprietaire = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Solde = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BanqueFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comptes", x => x.NumeroCompte);
                    table.ForeignKey(
                        name: "FK_Comptes_Banques_BanqueFk",
                        column: x => x.BanqueFk,
                        principalTable: "Banques",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompteFk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DabFK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Montant = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => new { x.DabFK, x.CompteFk, x.Date });
                    table.ForeignKey(
                        name: "FK_Transactions_Comptes_CompteFk",
                        column: x => x.CompteFk,
                        principalTable: "Comptes",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_DAB_DabFK",
                        column: x => x.DabFK,
                        principalTable: "DAB",
                        principalColumn: "DABId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionRetraits",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompteFk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DabFK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AutreAgence = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRetraits", x => new { x.DabFK, x.CompteFk, x.Date });
                    table.ForeignKey(
                        name: "FK_TransactionRetraits_Comptes_CompteFk",
                        column: x => x.CompteFk,
                        principalTable: "Comptes",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionRetraits_DAB_DabFK",
                        column: x => x.DabFK,
                        principalTable: "DAB",
                        principalColumn: "DABId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionRetraits_Transactions_DabFK_CompteFk_Date",
                        columns: x => new { x.DabFK, x.CompteFk, x.Date },
                        principalTable: "Transactions",
                        principalColumns: new[] { "DabFK", "CompteFk", "Date" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTransferts",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompteFk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DabFK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroCompte = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTransferts", x => new { x.DabFK, x.CompteFk, x.Date });
                    table.ForeignKey(
                        name: "FK_TransactionTransferts_Comptes_CompteFk",
                        column: x => x.CompteFk,
                        principalTable: "Comptes",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionTransferts_DAB_DabFK",
                        column: x => x.DabFK,
                        principalTable: "DAB",
                        principalColumn: "DABId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionTransferts_Transactions_DabFK_CompteFk_Date",
                        columns: x => new { x.DabFK, x.CompteFk, x.Date },
                        principalTable: "Transactions",
                        principalColumns: new[] { "DabFK", "CompteFk", "Date" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comptes_BanqueFk",
                table: "Comptes",
                column: "BanqueFk");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRetraits_CompteFk",
                table: "TransactionRetraits",
                column: "CompteFk");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CompteFk",
                table: "Transactions",
                column: "CompteFk");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTransferts_CompteFk",
                table: "TransactionTransferts",
                column: "CompteFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionRetraits");

            migrationBuilder.DropTable(
                name: "TransactionTransferts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Comptes");

            migrationBuilder.DropTable(
                name: "DAB");

            migrationBuilder.DropTable(
                name: "Banques");
        }
    }
}

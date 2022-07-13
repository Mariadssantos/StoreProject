using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace storeproject.Migrations
{
    public partial class client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientAdress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    PublicPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAdress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IdAdress = table.Column<int>(type: "int", nullable: false),
                    ClientAdressId = table.Column<int>(type: "int", nullable: true),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_ClientAdress_ClientAdressId",
                        column: x => x.ClientAdressId,
                        principalTable: "ClientAdress",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientAdressId",
                table: "Client",
                column: "ClientAdressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "ClientAdress");
        }
    }
}

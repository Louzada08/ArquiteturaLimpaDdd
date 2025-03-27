using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArqLimpaDDD.FrameworksAndDrivers.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", nullable: true),
                    fullname = table.Column<string>(type: "varchar(100)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "varchar(max)", nullable: false),
                    refreshtoken = table.Column<string>(type: "varchar(max)", nullable: true),
                    refreshTokenExpiryTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    userrole = table.Column<int>(type: "int", nullable: false),
                    createdat = table.Column<DateTime>(type: "datetime", nullable: true),
                    updatedat = table.Column<DateTime>(type: "datetime", nullable: true),
                    deletedat = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    launch_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<decimal>(type: "decimal(7,2)", nullable: true),
                    title = table.Column<string>(type: "varchar(max)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_book_user_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    createdat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedat = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_person_user_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_CreatedById",
                table: "book",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_person_CreatedById",
                table: "person",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_Id",
                table: "user",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}

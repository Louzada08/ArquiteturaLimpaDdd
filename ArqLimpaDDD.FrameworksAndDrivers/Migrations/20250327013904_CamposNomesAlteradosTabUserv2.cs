using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArqLimpaDDD.FrameworksAndDrivers.Migrations
{
    /// <inheritdoc />
    public partial class CamposNomesAlteradosTabUserv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "refreshTokenExpiryTime",
                table: "user",
                newName: "RefreshTokenExpiryTime");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "user",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "user",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "user",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Userrole",
                table: "user",
                newName: "UserRole");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "user",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Refreshtoken",
                table: "user",
                newName: "RefreshToken");

            migrationBuilder.RenameIndex(
                name: "IX_user_email",
                table: "user",
                newName: "IX_user_Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "user",
                newName: "Userrole");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "user",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpiryTime",
                table: "user",
                newName: "refreshTokenExpiryTime");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "user",
                newName: "Refreshtoken");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "user",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "user",
                newName: "email");

            migrationBuilder.RenameIndex(
                name: "IX_user_Email",
                table: "user",
                newName: "IX_user_email");
        }
    }
}

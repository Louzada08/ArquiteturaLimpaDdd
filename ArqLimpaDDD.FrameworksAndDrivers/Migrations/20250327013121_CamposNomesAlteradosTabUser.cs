using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArqLimpaDDD.FrameworksAndDrivers.Migrations
{
    /// <inheritdoc />
    public partial class CamposNomesAlteradosTabUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userrole",
                table: "user",
                newName: "Userrole");

            migrationBuilder.RenameColumn(
                name: "refreshtoken",
                table: "user",
                newName: "Refreshtoken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Userrole",
                table: "user",
                newName: "userrole");

            migrationBuilder.RenameColumn(
                name: "Refreshtoken",
                table: "user",
                newName: "refreshtoken");
        }
    }
}

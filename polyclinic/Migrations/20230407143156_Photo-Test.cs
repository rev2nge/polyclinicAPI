using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace polyclinic.Migrations
{
    /// <inheritdoc />
    public partial class PhotoTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Polyclinic",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Medic",
                newName: "Photo");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Specialization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolyclinicId",
                table: "Photo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecializationId",
                table: "Photo",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "Specialization",
                keyColumn: "Id",
                keyValue: 1,
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Specialization",
                keyColumn: "Id",
                keyValue: 2,
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Specialization",
                keyColumn: "Id",
                keyValue: 3,
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Specialization",
                keyColumn: "Id",
                keyValue: 4,
                column: "Photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "Specialization",
                keyColumn: "Id",
                keyValue: 5,
                column: "Photo",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PolyclinicId",
                table: "Photo",
                column: "PolyclinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_SpecializationId",
                table: "Photo",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Polyclinic_PolyclinicId",
                table: "Photo",
                column: "PolyclinicId",
                principalTable: "Polyclinic",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Specialization_SpecializationId",
                table: "Photo",
                column: "SpecializationId",
                principalTable: "Specialization",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Polyclinic_PolyclinicId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Specialization_SpecializationId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_PolyclinicId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_SpecializationId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Specialization");

            migrationBuilder.DropColumn(
                name: "PolyclinicId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "SpecializationId",
                table: "Photo");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Polyclinic",
                newName: "PhotoPath");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Medic",
                newName: "PhotoPath");

            migrationBuilder.UpdateData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Тирасполь");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace polyclinic.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Polyclinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polyclinic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polyclinic_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialization_Medic_MedicId",
                        column: x => x.MedicId,
                        principalTable: "Medic",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicPolyclinic",
                columns: table => new
                {
                    MedicsId = table.Column<int>(type: "int", nullable: false),
                    PolyclinicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicPolyclinic", x => new { x.MedicsId, x.PolyclinicsId });
                    table.ForeignKey(
                        name: "FK_MedicPolyclinic_Medic_MedicsId",
                        column: x => x.MedicsId,
                        principalTable: "Medic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicPolyclinic_Polyclinic_PolyclinicsId",
                        column: x => x.PolyclinicsId,
                        principalTable: "Polyclinic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Тирасполь" },
                    { 2, "Бендеры" },
                    { 3, "Каменка" },
                    { 4, "Слободзея" },
                    { 5, "Григориополь" }
                });

            migrationBuilder.InsertData(
                table: "Medic",
                columns: new[] { "Id", "Description", "Experience", "FullDescription", "FullName", "Phone", "PhotoPath", "Price" },
                values: new object[,]
                {
                    { 1, "Врач", "10 лет", "Классный врач", "Валерий Леонтьев Педросович", "111111", "", 121 },
                    { 2, "Врач", "20 лет", "Очень классный врач", "Григорий Леонтьев Педросович", "22222", "", 222 },
                    { 3, "Врач", "30 лет", "Супер врач", "Владислав Кириленко Васильевич", "33333", "", 332 }
                });

            migrationBuilder.InsertData(
                table: "Polyclinic",
                columns: new[] { "Id", "Address", "CityId", "Name", "Phone", "PhotoPath" },
                values: new object[,]
                {
                    { 1, "Гагарина 11", 1, "Поликлиника №1", "21313", "" },
                    { 2, "Гагарина 21", 2, "Поликлиника №2", "21213", "" },
                    { 3, "Гагарина 31", 3, "Поликлиника №3", "23213", "" }
                });

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "Id", "MedicId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Психолог" },
                    { 2, 2, "Невролог" },
                    { 3, 2, "Терапевт" },
                    { 4, 3, "Кардиолог" },
                    { 5, 3, "Психотерапевт" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicPolyclinic_PolyclinicsId",
                table: "MedicPolyclinic",
                column: "PolyclinicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Polyclinic_CityId",
                table: "Polyclinic",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_MedicId",
                table: "Specialization",
                column: "MedicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicPolyclinic");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Polyclinic");

            migrationBuilder.DropTable(
                name: "Medic");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
